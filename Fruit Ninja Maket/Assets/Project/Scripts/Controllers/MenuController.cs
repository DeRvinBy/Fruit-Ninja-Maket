using Project.Scripts.Animations.UIAnimations;
using Project.Scripts.Controllers.Save;
using Project.Scripts.UI.Game;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Controllers
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text scoreText = null;

        [SerializeField] 
        private SceneTransition sceneTransition = null;

        [SerializeField] 
        private SaveController saveController = null;
        
        [SerializeField] 
        private int gameSceneIndex = 0;
        
        private void Start()
        {
            sceneTransition.HideTransition(null);
            int score = 0;
            if (saveController != null)
            {
                score = saveController.PlayerSave.BestScore;
            }
            scoreText.text = score.ToString();
        }

        public void StartGameScene()
        {
            sceneTransition.ShowTransition(LoadGameScene);
        }

        private void LoadGameScene()
        {
            SceneManager.LoadScene(gameSceneIndex);
        }
    }
}
