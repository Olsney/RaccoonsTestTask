using Code.Gameplay.Input;
using Code.Infrastructure.Factory.Game;
using UnityEngine;

namespace Code.Gameplay.Cube.Spawner
{
    public class CubeSpawner : ICubeSpawner
    {
        private IGameFactory _gameFactory;
        private PlayerInputHandler _playerInputHandler;

        public CubeSpawner(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Initialize(PlayerInputHandler playerInputHandler)
        {
            _playerInputHandler = playerInputHandler;

            _playerInputHandler.TapEnded += Spawn;
        }

        private void Spawn(Vector2 at)
        {
            _gameFactory.CreateCube();
        }
    }
}