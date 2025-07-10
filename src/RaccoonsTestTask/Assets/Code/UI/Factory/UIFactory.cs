using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assets;
        
        private GameObject _uiRoot;

        public UIFactory(IInstantiator instantiator, IAssetProvider assets)
        {
            _instantiator = instantiator;
            _assets = assets;
        }
        
        public GameObject CreateUIRoot()
        {
            GameObject prefab = _assets.Load(AssetPath.UIRoothPath);
            _uiRoot = _instantiator.InstantiatePrefab(prefab);
            
            return null;
        }

        public GameObject CreateHud()
        {
            GameObject prefab = _assets.Load(AssetPath.HudPath);
            
            return _instantiator.InstantiatePrefab(prefab, Vector3.zero, 
                Quaternion.identity, null);
        }

        public GameObject CreateVictoryWindow()
        {
            GameObject prefab = _assets.Load(AssetPath.VictoryWindowPath);
            
            return _instantiator.InstantiatePrefab(prefab, Vector3.zero, 
                Quaternion.identity, _uiRoot.transform);
            
        }

        public GameObject CreateLoseWindow()
        {
            GameObject prefab = _assets.Load(AssetPath.LoseWindowPath);
            
            return _instantiator.InstantiatePrefab(prefab, Vector3.zero, 
                Quaternion.identity, _uiRoot.transform);        }
    }
}