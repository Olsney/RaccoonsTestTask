using Code.Services.SpawnPointProviders;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cube
{
    public class CubeSpawnPoint : MonoBehaviour
    {
        private ICubeSpawnPointProvider _cubeSpawnPointProvider;

        [Inject]
        public void Construct(ICubeSpawnPointProvider cubeSpawnPointProvider)
        {
            _cubeSpawnPointProvider = cubeSpawnPointProvider;
        }

        private void Awake()
        {
            _cubeSpawnPointProvider.Instance = this;
        }
    }
}