using Code.Gameplay.Input;
using Code.Infrastructure.Factory.Game;
using Code.Services.InputHandlerProvider;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cube.Spawner
{
    public class CubeSpawner : MonoBehaviour
    {
        private IPlayerInputHandlerProvider _playerInputHandlerProvider;
        private IGameFactory _gameFactory;
        private PlayerInputHandler _playerInputHandler;

        [Inject]
        public void Construct(IGameFactory gameFactory, 
            IPlayerInputHandlerProvider playerInputHandlerProvider)
        {
            _gameFactory = gameFactory;
            _playerInputHandlerProvider = playerInputHandlerProvider;
        }

        public void Initialize()
        {
            _playerInputHandler = _playerInputHandlerProvider.Get();
            
            _playerInputHandler.TapEnded += Spawn;
        }

        private void Spawn(Vector2 position)
        {
            _gameFactory.CreateCube();
        }
    }
}