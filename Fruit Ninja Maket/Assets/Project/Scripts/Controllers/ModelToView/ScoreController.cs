using Project.Scripts.Controllers.Save;
using Project.Scripts.GameSettings.ScoreSettings;
using Project.Scripts.UI.Score;
using UnityEngine;

namespace Project.Scripts.Controllers.ModelToView
{
    public class ScoreController : MonoBehaviour
    {
        private const int StartComboMultiplier = 1;
        
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

        private float comboTime;
        private int comboMultiplier;
        private int bestScore;
        private int currentScore;

        public int BestScore => bestScore;
        public int CurrentScore => currentScore;
        public int ScoreMultiplier => controllerSettings.ScoreMultiplyCoefficient;

        private void Start()
        {
            mainCamera = Camera.main;
            saveController = resourceManager.GetSaveController();
            Initialize();
        }

        private void Update()
        {
            comboTime += Time.deltaTime;
        }

        public void Initialize()
        {
            comboMultiplier = StartComboMultiplier;
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
            var multipliedScore = MultiplyScoreByCoefficients(score);
            currentScore += multipliedScore;
            scoreUI.SetCurrentScoreAnimate(currentScore);
            if(currentScore > bestScore)
            {
                bestScore = currentScore;
                scoreUI.SetBestScoreAnimate(currentScore);
            }

            Vector2 screenPosition = mainCamera.WorldToScreenPoint(slicingPosition);
            CreateSceneScore(screenPosition, multipliedScore);
        }
        
        private int MultiplyScoreByCoefficients(int score)
        {
            UpdateComboMultiplier();
            return score * comboMultiplier * ScoreMultiplier;
        }
        
        private void UpdateComboMultiplier()
        {
            if (comboTime <= controllerSettings.MaxTimeToIncreaseCombo)
            {
                comboMultiplier++;
                if (comboMultiplier > controllerSettings.MaxScoreCombo)
                {
                    comboMultiplier = controllerSettings.MaxScoreCombo;
                }
            }
            else
            {
                comboMultiplier = StartComboMultiplier;
            }
            
            comboTime = 0f;
        }
        
        private void CreateSceneScore(Vector2 position, int score)
        {
            var sceneScore = Instantiate(controllerSettings.SceneScorePrefab, position, Quaternion.identity, uiTransform);
            sceneScore.InitializeScore(score, comboMultiplier);
        }

        public void SetBestScoreInSave()
        {
            saveController.PlayerSave.SetBestScore(bestScore);
            saveController.SavePlayerStats();
        }
    }
}
