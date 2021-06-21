using Project.Scripts.Controllers.Save;
using Project.Scripts.GameSettings.ScoreSettings;
using Project.Scripts.UI.Score;
using UnityEngine;

namespace Project.Scripts.Controllers.ModelToView
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] 
        private ResourceManager resourceManager = null;
        
        [SerializeField]
        private ScoreControllerSettings controllerSettings = null;

        [SerializeField]
        private Transform uiTransform = null;

        [SerializeField]
        private ScoreUI scoreUI = null;

        private ISaveController saveController;
        private Camera mainCamera;
        private int bestScore;
        private int currentScore;

        public int BestScore => bestScore;
        public int CurrentScore => currentScore;

        private void Start()
        {
            mainCamera = Camera.main;
            saveController = resourceManager.GetSaveController();
            Initialize();
        }

        public void Initialize()
        {
            currentScore = 0;
            scoreUI.SetCurrentScore(currentScore);
            bestScore = 0;
            if (saveController != null)
            {
                bestScore = saveController.PlayerSave.BestScore;
            }

            scoreUI.SetBestScore(bestScore);
        }

        public void AddScoreByFruit(Vector2 slicingPosition, int score)
        {
            currentScore += score;
            scoreUI.SetCurrentScore(currentScore);
            if(currentScore > bestScore)
            {
                bestScore = currentScore;
                scoreUI.SetBestScore(currentScore);
            }

            Vector2 screenPosition = mainCamera.WorldToScreenPoint(slicingPosition);
            CreateSceneScore(screenPosition, score);
        }

        public void SetBestScoreInSave()
        {
            saveController.PlayerSave.SetBestScore(bestScore);
        }

        private void CreateSceneScore(Vector2 position, int score)
        {
            var sceneScore = Instantiate(controllerSettings.SceneScorePrefab, position, Quaternion.identity, uiTransform);
            sceneScore.InitializeScore(score);
        }
    }
}
