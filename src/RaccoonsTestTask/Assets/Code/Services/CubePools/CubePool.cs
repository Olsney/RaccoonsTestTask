using System.Collections.Generic;
using Code.Gameplay.Cubes;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Services.CubePools
{
    public class CubePool : ICubePool
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assets;
        private readonly Stack<GameObject> _pool = new();
        
        private GameObject _prefab;

        public CubePool(IInstantiator instantiator, IAssetProvider assets)
        {
            _instantiator = instantiator;
            _prefab = assets.Load(AssetPath.CubePath);
        }

        public GameObject Get(Vector3 position, Quaternion rotation)
        {
            GameObject cube = _pool.Count > 0
                ? _pool.Pop()
                : _instantiator.InstantiatePrefab(_prefab, position, rotation, null);

            cube.transform.SetPositionAndRotation(position, rotation);
            cube.SetActive(true);
            
            return cube;
        }

        public void Release(GameObject cubeObject)
        {
            cubeObject.SetActive(false);

            Cube cube = cubeObject.GetComponent<Cube>();
            cube.Cleanup();

            _pool.Push(cubeObject);
        }
    }
}