using Code.Services.Merge;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cubes
{
    public class Cube : MonoBehaviour
    {
        [SerializeField] private float _minMergeImpulse = 0.1f;

        private IMergeService _mergeService;
        private Rigidbody _rigidbody;

        public bool IsMerging { get; private set; }
        public bool IsInGame { get; private set; }
        public bool ReachedGameOverPoint { get; private set; }
        
        public int Value { get; private set; }

        [Inject]
        public void Construct(IMergeService mergeService)
        {
            _mergeService = mergeService;
        }

        public void Initialize(int value)
        {
            Value = value;
            
            IsMerging = false;

            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (IsMerging)
                return;

            if (!collision.transform.TryGetComponent(out Cube cube))
                return;

            if (cube == this || cube.IsMerging)
                return;

            if (Value != cube.Value)
                return;

            Vector3 directionToOther = (cube.transform.position - transform.position).normalized;
            float velocityTowards = Vector3.Dot(_rigidbody.linearVelocity, directionToOther);

            if (velocityTowards < _minMergeImpulse)
                return;
            
            IsMerging = true;
            
            _mergeService.Merge(this, cube);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out GameOverPoint losePoint) == false)
                return;

            if (IsInGame == false)
            {
                IsInGame = true;
                
                return;
            }

            if (IsInGame)
            {
                ReachedGameOverPoint = true;
                
                losePoint.Finish(cube: this);
            }

        }

        public void MarkAsMerging() => 
            IsMerging = true;

        public void MarkAsInGame() =>
            IsInGame = true;
    }
}