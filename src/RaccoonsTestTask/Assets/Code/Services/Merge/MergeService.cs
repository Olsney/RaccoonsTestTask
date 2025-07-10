using Code.Data;
using Code.Gameplay.Cubes;
using Code.Gameplay.Cubes.Spawner;
using Code.Infrastructure.Factory.Game;
using Code.Services.CubeSpawnerProviders;
using UnityEngine;

namespace Code.Services.Merge
{
    public class MergeService : IMergeService
    {
        private readonly IGameFactory _gameFactory;
        private readonly ICubeSpawnerProvider _spawnerProvider;
        private readonly IWorldData _worldData;

        public MergeService(IGameFactory gameFactory, 
            ICubeSpawnerProvider spawnerProvider,
            IWorldData worldData)
        {
            _gameFactory = gameFactory;
            _spawnerProvider = spawnerProvider;
            _worldData = worldData;
        }

        public void Merge(Cube first, Cube second)
        {
            CubeSpawner cubeSpawner = _spawnerProvider.Instance;
            
            if (first == null || second == null)
                return;
            
            first.MarkAsMerging();
            second.MarkAsMerging();
            
            _worldData.AddScore(first.Value + second.Value);
            
            int newCubeValue = first.Value + second.Value;
            Vector3 spawnPosition = GetSpawnPosition(first, second);

            cubeSpawner.SpawnMerge(newCubeValue, spawnPosition);
            
            Object.Destroy(first.gameObject);
            Object.Destroy(second.gameObject);
        }

        private static Vector3 GetSpawnPosition(Cube first, Cube second) => 
            (first.transform.position + second.transform.position) / 2f;
    }
}