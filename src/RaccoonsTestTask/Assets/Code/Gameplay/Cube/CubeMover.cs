using Code.Gameplay.Input;
using Code.Services.InputHandlerProvider;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cube
{
    public class CubeMover : MonoBehaviour
    {
        [SerializeField] private float _moveLimitX = 3f;
        [SerializeField] private float _distanceFromCamera = 10f; 
        
        private IPlayerInputHandlerProvider _playerInputHandlerProvider;
        private PlayerInputHandler _playerInputHandler;
        private Camera _mainCamera;
        private Rigidbody _rigidbody;
        private bool _isDragging;


        [Inject]
        public void Construct(IPlayerInputHandlerProvider playerInputHandlerProvider)
        {
            _playerInputHandlerProvider = playerInputHandlerProvider;
            _rigidbody = GetComponent<Rigidbody>();

            _mainCamera = Camera.main;
        }

        public void Initialize()
        {
            _playerInputHandler = _playerInputHandlerProvider.Get();

            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true; // пока не бросили, отключаем физику
            _mainCamera = Camera.main;
            
            _playerInputHandler.TapStarted += OnTapStarted;
            _playerInputHandler.TapEnded += OnTapEnded;
        }
        
        private void Update()
        {
            if (!_isDragging || _rigidbody == null || !_rigidbody.isKinematic)
                return;

            MoveWithPointer(_playerInputHandler.PointerPosition());
        }
        
        private void OnDestroy()
        {
                _playerInputHandler.TapStarted -= OnTapStarted;
                _playerInputHandler.TapEnded -= OnTapEnded;
        }

        private void OnTapStarted(Vector2 obj)
        {
            _isDragging = true;
        }

        private void OnTapEnded(Vector2 obj)
        {
            _isDragging = false;

            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(Vector3.right * -500f);
        }
        
        private void MoveWithPointer(Vector2 screenPosition)
        {
            Vector3 worldPointerPosition = _mainCamera.ScreenToWorldPoint(
                new Vector3(screenPosition.x, screenPosition.y, _distanceFromCamera));
            Vector3 positionToChange = transform.position;
            positionToChange.z = Mathf.Clamp(worldPointerPosition.z, -_moveLimitX, _moveLimitX);
            transform.position = positionToChange;
        }
    }
}