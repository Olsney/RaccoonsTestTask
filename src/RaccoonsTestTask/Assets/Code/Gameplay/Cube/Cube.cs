using Code.Services.Merge;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cube
{
    public class Cube : MonoBehaviour
    {
        private IMergeService _mergeService;
        
        public int Value { get; private set; }

        [Inject]
        public void Construct(IMergeService mergeService)
        {
            _mergeService = mergeService;
        }

        public void Initialize()
        {
            
        }
    }
}