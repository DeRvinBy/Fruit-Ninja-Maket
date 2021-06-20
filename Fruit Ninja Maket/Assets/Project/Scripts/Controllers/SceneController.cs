using Project.Scripts.UI.Game;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Controllers
{
    public class SceneController : MonoBehaviour
    {
        public UnityEvent OnTransitionEnded = new UnityEvent();
        
        [SerializeField] 
        private int nextGameSceneIndex = 0;
        
        [SerializeField] 
        private SceneTransition sceneTransition = null;

        private void OnDestroy()
        {
            OnTransitionEnded?.RemoveAllListeners();
        }

        private void Start()
        {
            sceneTransition.HideTransition(() => OnTransitionEnded?.Invoke());
        }

        public void StartNextScene()
        {
            sceneTransition.ShowTransition(LoadNextScene);
        }

        private void LoadNextScene()
        {
            SceneManager.LoadScene(nextGameSceneIndex);
        }
    }
}