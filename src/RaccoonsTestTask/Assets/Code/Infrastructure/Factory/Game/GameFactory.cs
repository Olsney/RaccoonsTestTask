using Code.Gameplay.Cube;
using Code.Gameplay.Cube.Spawner;
using Code.Gameplay.Input;
using Code.Infrastructure.AssetManagement;
using Code.Services.InputHandlerProvider;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory.Game
{
    public class GameFactory : IGameFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assets;
        private readonly IPlayerInputHandlerProvider _playerInputHandlerProvider;
        private readonly ICubeSpawner _cubeSpawner;

        public GameFactory(IInstantiator instantiator, 
            IAssetProvider assets,
            IPlayerInputHandlerProvider playerInputHandlerProvider,
            ICubeSpawner cubeSpawner)
        {
            _instantiator = instantiator;
            _assets = assets;
            _playerInputHandlerProvider = playerInputHandlerProvider;
            _cubeSpawner = cubeSpawner;
        }
        
        public GameObject CreatePlayerInputHandler()
        {
            GameObject prefab = _assets.Load(AssetPath.PlayerInputHandlerPath);

            GameObject instance = _instantiator.InstantiatePrefab(prefab, Vector3.zero, Quaternion.identity, null);

            PlayerInputHandler playerInputHandler = instance.GetComponent<PlayerInputHandler>();
            _playerInputHandlerProvider.Set(playerInputHandler);
            
            _cubeSpawner.Initialize(playerInputHandler);
            
            return instance;
        }

        public GameObject CreateCube()
        {
            GameObject prefab = _assets.Load(AssetPath.CubePath);
            
            GameObject instance = _instantiator.InstantiatePrefab(prefab, Vector3.zero, Quaternion.identity, null);
            
            CubeMover cubeMover = instance.GetComponent<CubeMover>();
            cubeMover.Initialize();

            return instance;
        }
    }
}