using System.Collections.Generic;
using Code.Gameplay.Input;
using Code.Infrastructure.Factory.Game;
using Code.Services.InputHandlerProvider;
using Code.Services.Random;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Gameplay.Cubes.Spawner
{
    public class CubeSpawner : MonoBehaviour
    {
        private IPlayerInputHandlerProvider _playerInputHandlerProvider;
        private IGameFactory _gameFactory;
        private PlayerInputHandler _playerInputHandler;
        private IRandomService _randomService;


        //Это итеративный враиант - дальше был бы настроенный ScriptableObject,
        //я бы через StaticDataService доставал конфиг
        //и дальше бы уже брал нужное сочетание значения и цвета.

        private static readonly Dictionary<int, Color> _colorByCubeValue = new()
        {
            { 2, new Color(0.9f, 0.9f, 1f) },
            { 4, new Color(0.7f, 1f, 0.7f) },
            { 8, new Color(1f, 1f, 0.6f) },
            { 16, new Color(1f, 0.85f, 0.5f) },
            { 32, new Color(1f, 0.6f, 0.6f) },
            { 64, new Color(0.9f, 0.5f, 1f) },
            { 128, new Color(0.6f, 0.8f, 1f) },
            { 256, new Color(0.4f, 0.9f, 0.7f) },
            { 512, new Color(1f, 0.8f, 0.2f) },
            { 1024, new Color(1f, 0.4f, 0.4f) },
            { 2048, new Color(0.5f, 0.3f, 1f) },
            { 4096, new Color(0.3f, 0.7f, 0.9f) },
            { 8192, new Color(0.2f, 0.9f, 0.6f) },
            { 16384, new Color(1f, 0.7f, 0f) },
            { 32768, new Color(0.9f, 0.3f, 0.3f) },
            { 65536, new Color(0.4f, 0.2f, 0.8f) },
            { 131072, new Color(0.2f, 0.6f, 0.9f) },
            { 262144, new Color(0.1f, 0.8f, 0.4f) },
            { 524288, new Color(1f, 0.6f, 0.1f) },
            { 1048576, new Color(0.7f, 0.1f, 0.1f) }
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

        private static void AddRandomForceToNewCube(Rigidbody rb)
        {
            Vector3 randomDirection = Vector3.up + new Vector3(
                Random.Range(-0.5f, 0.5f),
                0f,
                Random.Range(-0.5f, 0.5f)
            ).normalized;
            rb.AddForce(randomDirection * 0.5f, ForceMode.Impulse);
        }
    }
}