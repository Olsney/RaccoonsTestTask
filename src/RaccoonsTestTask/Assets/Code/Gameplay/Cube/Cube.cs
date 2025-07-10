using Code.Services.Merge;
using Code.Services.Random;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Cube
{
    public class Cube : MonoBehaviour
    {
        [SerializeField] private float _minMergeImpulse = 0.5f;
        
        private IMergeService _mergeService;
        private Rigidbody _rigidbody;

        public bool IsMerging { get; set; }
        

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

            Debug.Log(Value);
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

            _mergeService.Merge(this, cube);
        }
    }
}