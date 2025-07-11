using System.Collections.Generic;
using Code.Gameplay.Input;
using Code.Infrastructure.Factory.Game;
using Code.Services.InputHandlerProviders;
using Code.Services.Randoms;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cubes.Spawner
{
    public class CubeSpawner : MonoBehaviour
    {
        private const float ForceModifier = 3f;
        private IPlayerInputHandlerProvider _playerInputHandlerProvider;
        private IGameFactory _gameFactory;
        private PlayerInputHandler _playerInputHandler;
        private IRandomService _randomService;

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

        public GameObject SpawnMerge(int cubeValue, Vector3 at)
        {
            GameObject mergedCube = _gameFactory.CreateCube(cubeValue, at);
            SetColor(mergedCube, cubeValue);

            Cube cube = mergedCube.GetComponent<Cube>();
            cube.MarkAsInGame();

            Rigidbody rigidbody = mergedCube.GetComponent<Rigidbody>();
            AddRandomForceToNewCube(rigidbody);

            return mergedCube;
        }

        private void SpawnRandomAtStartPoint(Vector2 position)
        {
            int cubeValue = _randomService.GetRandomPo2Value();

            GameObject cube = _gameFactory.CreateCube(cubeValue);

            SetColor(cube, cubeValue);
        }

        private void SetColor(GameObject cube, int value)
        {
            if (CubeColors.TryGet(value, out Color color))
            {
                if (cube.TryGetComponent(out Renderer renderer))
                    renderer.material.color = color;
            }
        }

        private void AddRandomForceToNewCube(Rigidbody rigidbody)
        {
            float min = -1f;
            float max = 1f;

            Vector3 randomDirection = Vector3.up + new Vector3(
                _randomService.Next(min, max),
                _randomService.Next(min, max),
                _randomService.Next(min, max)
            ).normalized;

            rigidbody.AddForce(randomDirection * ForceModifier, ForceMode.Impulse);
        }
    }
}