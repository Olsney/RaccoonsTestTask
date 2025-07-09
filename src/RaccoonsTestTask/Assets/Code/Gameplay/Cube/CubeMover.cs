using Code.Gameplay.Input;
using Code.Services.InputHandlerProvider;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cube
{
    public class CubeMover : MonoBehaviour
    {
        private IPlayerInputHandlerProvider _playerInputHandlerProvider;
        private PlayerInputHandler _playerInputHandler;

        [Inject]
        public void Construct(IPlayerInputHandlerProvider playerInputHandlerProvider)
        {
            _playerInputHandlerProvider = playerInputHandlerProvider;
        }

        public void Initialize()
        {
            _playerInputHandler = _playerInputHandlerProvider.Get();

            _playerInputHandler.TapStarted += OnTapStarted;
            _playerInputHandler.TapEnded += OnTapEnded;
        }

        private void OnTapStarted(Vector2 obj)
        {
            
        }

        private void OnTapEnded(Vector2 obj)
        {
        }
    }
}