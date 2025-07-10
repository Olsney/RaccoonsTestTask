using System;
using Code.Gameplay.Input;
using Code.Services.InputHandlerProvider;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cube
{
    public class CubeMover : MonoBehaviour
    {
        [SerializeField] private float _moveLimitZ = 3f;
        [SerializeField] private float _distanceFromCamera = 10f;
        [SerializeField] private float _launchForce = 500f;

        private Rigidbody _rigidbody;
        private Camera _mainCamera;
        private bool _isDragging;
        private bool _isLaunched;

        private PlayerInputHandler _input;

        [Inject]
        public void Construct(IPlayerInputHandlerProvider inputProvider)
        {
            _input = inputProvider.Get();
        }

        public void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            _mainCamera = Camera.main;

            _input.TapStarted += OnTapStarted;
            _input.TapEnded += OnTapEnded;
        }

        public void Dispose()
        {
            _input.TapStarted -= OnTapStarted;
            _input.TapEnded -= OnTapEnded;
        }

        private void Update()
        {
            if (_isDragging && !_isLaunched)
                DragWithPointer(_input.PointerPosition());
        }

        private void OnTapStarted(Vector2 pos)
        {
            if (_isLaunched) return;
            _isDragging = true;
        }

        private void OnTapEnded(Vector2 pos)
        {
            if (_isLaunched) return;

            _isDragging = false;
            _isLaunched = true;
            _rigidbody.isKinematic = false;
            _rigidbody.linearVelocity = Vector3.zero;
            _rigidbody.linearVelocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation |
                                     RigidbodyConstraints.FreezePositionZ;
            _rigidbody.AddForce(Vector3.left * _launchForce, ForceMode.Impulse);    }

        private void DragWithPointer(Vector2 screenPos)
        {
            Vector3 world = _mainCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, _distanceFromCamera));
            var pos = transform.position;
            pos.z = Mathf.Clamp(world.z, -_moveLimitZ, _moveLimitZ);
            transform.position = pos;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CubeRotationActivator rotationActivator) == false)
                return;
            
            _rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}