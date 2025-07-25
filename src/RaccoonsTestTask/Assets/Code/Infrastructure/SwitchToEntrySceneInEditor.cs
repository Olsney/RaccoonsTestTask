using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.Infrastructure
{
    public class SwitchToEntrySceneInEditor : MonoBehaviour
    {
#if UNITY_EDITOR
        private const string EntrySceneName = "Initial";

        private void Awake()
        {
            if (ProjectContext.HasInstance)
                return;

            foreach (GameObject root in gameObject.scene.GetRootGameObjects())
                root.SetActive(false);

            SceneManager.LoadScene(EntrySceneName);
        }
#endif
    }
}