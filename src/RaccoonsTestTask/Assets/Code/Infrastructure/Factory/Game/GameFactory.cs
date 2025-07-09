using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory.Game
{
    public class GameFactory : IGameFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assets;

        public GameFactory(IInstantiator instantiator, IAssetProvider assets)
        {
            _instantiator = instantiator;
            _assets = assets;
        }
        
        public GameObject CreatePlayerInputHandler()
        {
            GameObject prefab = _assets.Load(AssetPath.PlayerInputHandlerPath);

            GameObject instance = _instantiator.InstantiatePrefab(prefab, Vector3.zero, Quaternion.identity, null);
            
            return instance;
        }
    }
}