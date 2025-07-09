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
            _rigidbody.AddForce(Vector3.left * _launchForce);
        }

        private void DragWithPointer(Vector2 screenPos)
        {
            Vector3 world = _mainCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, _distanceFromCamera));
            var pos = transform.position;
            pos.z = Mathf.Clamp(world.z, -_moveLimitZ, _moveLimitZ);
            transform.position = pos;
        }
    }
}