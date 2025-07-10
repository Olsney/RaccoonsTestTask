using Code.Gameplay.Cube.Spawner;
using Code.Infrastructure.Factory.Game;
using Code.Services.CubeSpawnerProviders;
using UnityEngine;

namespace Code.Services.Merge
{
    public class MergeService : IMergeService
    {
        private readonly IGameFactory _gameFactory;
        private readonly ICubeSpawnerProvider _spawnerProvider;

        public MergeService(IGameFactory gameFactory, ICubeSpawnerProvider spawnerProvider)
        {
            _gameFactory = gameFactory;
            _spawnerProvider = spawnerProvider;
        }

        public void Merge()
        {
            int po2Value = 2;
            Vector3 spawnPosition = Vector3.zero;
            
            CubeSpawner cubeSpawner = _spawnerProvider.Instance;
            
            cubeSpawner.SpawnMerge(po2Value, spawnPosition);
        }
    }
}