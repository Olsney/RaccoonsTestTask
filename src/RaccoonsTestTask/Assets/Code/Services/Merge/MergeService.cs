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
            if (first == null || second == null)
                return;

            first.MarkAsMerging();
            second.MarkAsMerging();

            int newCubeValue = first.Value + second.Value;
            int scoreReward = CalculateScoreReward(newCubeValue);

            _worldData.AddScore(scoreReward);

            Vector3 spawnPosition = GetSpawnPosition(first, second);
            _spawnerProvider.Instance.SpawnMerge(newCubeValue, spawnPosition);

            Object.Destroy(first.gameObject);
            Object.Destroy(second.gameObject);
        }

        private static int CalculateScoreReward(int mergedValue) => 
            mergedValue / 2;

        private static Vector3 GetSpawnPosition(Cube first, Cube second) =>
            (first.transform.position + second.transform.position) / 2f;
    }
}