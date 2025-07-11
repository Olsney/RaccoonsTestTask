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

        private static readonly Dictionary<int, Color> _colorByCubeValue = new()
        {
            { 2, new Color(0.85f, 0.92f, 0.98f) },
            { 4, new Color(0.50f, 0.78f, 0.96f) },
            { 8, new Color(0.96f, 0.80f, 0.60f) },
            { 16, new Color(0.98f, 0.68f, 0.42f) },
            { 32, new Color(0.98f, 0.48f, 0.37f) },
            { 64, new Color(0.94f, 0.30f, 0.23f) },
            { 128, new Color(0.93f, 0.81f, 0.45f) },
            { 256, new Color(0.93f, 0.78f, 0.31f) },
            { 512, new Color(0.93f, 0.76f, 0.15f) },
            { 1024, new Color(0.93f, 0.69f, 0.07f) },
            { 2048, new Color(0.90f, 0.60f, 0.00f) },
            { 4096, new Color(0.45f, 0.36f, 0.74f) },
            { 8192, new Color(0.33f, 0.60f, 0.78f) },
            { 16384, new Color(0.24f, 0.67f, 0.47f) },
            { 32768, new Color(0.85f, 0.28f, 0.36f) },
            { 65536, new Color(0.53f, 0.24f, 0.75f) },
            { 131072, new Color(0.28f, 0.56f, 0.76f) },
        };


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
            if (_colorByCubeValue.TryGetValue(value, out Color color))
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