using Code.Data;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        protected IWorldData WorldData;

        [SerializeField] private Button _closeButton;
        protected int Score => WorldData.Score;
        
        [Inject]
        public void Construct(IWorldData worldData)
        {
            WorldData = worldData;
        }

        private void Awake() => 
            OnAwake();

        private void Start()
        {
            Initialize();
            SubscribeUpdates();
        }

        private void OnDestroy()
        {
            Cleanup();
        }

        protected virtual void OnAwake()
        {
            if (_closeButton != null)
                _closeButton.onClick.AddListener(() => Destroy(gameObject));

            transform.localScale = Vector3.zero;
        }
        
        protected virtual void Initialize() { }

        protected virtual void SubscribeUpdates() { }

        protected virtual void Cleanup() { }
    }
}