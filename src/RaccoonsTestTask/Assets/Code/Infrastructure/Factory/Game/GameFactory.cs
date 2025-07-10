using Code.Gameplay.Cube;
using Code.Gameplay.Cube.Spawner;
using Code.Gameplay.Input;
using Code.Infrastructure.AssetManagement;
using Code.Services.InputHandlerProvider;
using Code.Services.Random;
using Code.Services.SpawnPointProviders;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory.Game
{
    public class GameFactory : IGameFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assets;
        private readonly IPlayerInputHandlerProvider _playerInputHandlerProvider;
        private readonly ICubeSpawnPointProvider _cubeSpawnPointProvider;
        private readonly IRandomService _randomService;

        public GameFactory(IInstantiator instantiator, 
            IAssetProvider assets,
            IPlayerInputHandlerProvider playerInputHandlerProvider,
            ICubeSpawnPointProvider cubeSpawnPointProvider,
            IRandomService randomService)
        {
            _instantiator = instantiator;
            _assets = assets;
            _playerInputHandlerProvider = playerInputHandlerProvider;
            _cubeSpawnPointProvider = cubeSpawnPointProvider;
            _randomService = randomService;
        }
        
        public GameObject CreatePlayerInputHandler()
        {
            GameObject prefab = _assets.Load(AssetPath.PlayerInputHandlerPath);

            GameObject instance = _instantiator.InstantiatePrefab(prefab, Vector3.zero, Quaternion.identity, null);

            PlayerInputHandler playerInputHandler = instance.GetComponent<PlayerInputHandler>();
            _playerInputHandlerProvider.Set(playerInputHandler);
            
            return instance;
        }

        public GameObject CreateCubeSpawner()
        {
            GameObject prefab = _assets.Load(AssetPath.CubeSpawnerPath);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, Vector3.zero, Quaternion.identity, null);

            CubeSpawner cubeSpawner = instance.GetComponent<CubeSpawner>();
            cubeSpawner.Initialize();

            return instance;
        }

        public GameObject CreateCube()
        {
            GameObject prefab = _assets.Load(AssetPath.CubePath);
            CubeSpawnPoint spawnPoint = _cubeSpawnPointProvider.Instance;
            
            GameObject instance = _instantiator.InstantiatePrefab(prefab, spawnPoint.transform.position, Quaternion.identity, null);
            
            CubeMover cubeMover = instance.GetComponent<CubeMover>();
            cubeMover.Initialize();

            Cube cube = instance.GetComponent<Cube>();
            cube.Initialize(_randomService.GetRandomPo2Value());

            return instance;
        }
    }
}