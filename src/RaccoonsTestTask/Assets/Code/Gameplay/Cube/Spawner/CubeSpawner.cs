using System;
using System.Collections.Generic;
using Code.Gameplay.Input;
using Code.Infrastructure.Factory.Game;
using Code.Services.InputHandlerProvider;
using Code.Services.Random;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cube.Spawner
{
    public class CubeSpawner : MonoBehaviour
    {
        private IPlayerInputHandlerProvider _playerInputHandlerProvider;
        private IGameFactory _gameFactory;
        private PlayerInputHandler _playerInputHandler;
        private IRandomService _randomService;

        private Dictionary<Enum, Color> _cubeColors = new Dictionary<Enum, Color>();

        [Inject]
        public void Construct(IGameFactory gameFactory, 
            IPlayerInputHandlerProvider playerInputHandlerProvider,
            IRandomService randomService)
        {
            _gameFactory = gameFactory;
            _playerInputHandlerProvider = playerInputHandlerProvider;
            _randomService = randomService;
        }

        public void Initialize()
        {
            _playerInputHandler = _playerInputHandlerProvider.Get();
            
            _playerInputHandler.TapEnded += SpawnRandomAtStartPoint;
        }

        public GameObject SpawnMerge(int cubeValue, Vector3 at) => 
            _gameFactory.CreateCube(cubeValue, at);

        private void SpawnRandomAtStartPoint(Vector2 position) => 
            _gameFactory.CreateCube(_randomService.GetRandomPo2Value());
    }
}