using Code.Services.Merge;
using Code.Services.Random;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cube
{
    public class Cube : MonoBehaviour
    {
        private const int MaxValueForLaunchedCube = 4;
        private IMergeService _mergeService;
        private IRandomService _randomService;

        public int Value { get; private set; }

        [Inject]
        public void Construct(IMergeService mergeService, IRandomService randomService)
        {
            _mergeService = mergeService;
            _randomService = randomService;
        }

        public void Initialize(int value)
        {
            Value = value;
            
            Debug.Log("Value");
        }
    }
}