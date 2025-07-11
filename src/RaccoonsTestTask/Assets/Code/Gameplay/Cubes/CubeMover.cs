using Code.Gameplay.Input;
using Code.Services.InputHandlerProviders;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cubes
{
    public class CubeMover : MonoBehaviour
    {
        [SerializeField] private float _leftLimitZ = -0.6f;
        [SerializeField] private float _rightLimitZ = 2.7f;
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

            _isDragging = false;
            _isLaunched = false;
            
            _mainCamera = Camera.main;

            _input.TapStarted += OnTapStarted;
            _input.TapEnded += OnTapEnded;
        }
        
        public void Cleanup()
        {
            _input.TapStarted -= OnTapStarted;
            _input.TapEnded -= OnTapEnded;
        }

        public void OnDestroy()
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
            if (_isLaunched) 
                return;
            
            _isDragging = true;
        }

        private void OnTapEnded(Vector2 pos)
        {
            if (_isLaunched) 
                return;

            _isDragging = false;
            _isLaunched = true;

            _rigidbody.isKinematic = false;
            _rigidbody.linearVelocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;

            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            _rigidbody.AddForce(Vector3.left * _launchForce, ForceMode.Impulse);
        }

        private void DragWithPointer(Vector2 screenPosition)
        {
            Vector3 cameraPosition = _mainCamera.ScreenToWorldPoint(new Vector3(
                screenPosition.x, screenPosition.y, _distanceFromCamera));
            Vector3 cubePermissiblePosition = transform.position;
            cubePermissiblePosition.z = Mathf.Clamp(
                cameraPosition.z, 
                _leftLimitZ, 
                _rightLimitZ);
            
            transform.position = cubePermissiblePosition;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_rigidbody == null)
                return;
            
            if (other.TryGetComponent(out CubeRotationActivator _)) 
                _rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}