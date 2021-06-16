using Scripts.GameSettings.ScoreSettings;
using Scripts.UI.Score;
using UnityEngine;

namespace Scripts.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField]
        private ScoreControllerSettings controllerSettings = null;

        [SerializeField]
        private Transform canvas = null;

        [SerializeField]
        private ScoreUI scoreUI = null;

        private int bestScore;
        private int currentScore;

        public int BestScore { get => bestScore; }
        public int CurrentScore { get => currentScore; }

        public void Initialize()
        {
            currentScore = 0;
            bestScore = 200;
            scoreUI.SetBestScore(bestScore);
        }

        public void AddScoreByFruit(Vector2 slicingPosition)
        {
            currentScore += controllerSettings.ScoreValueByOneFruit;
            scoreUI.SetCurrentScore(currentScore);
            if(currentScore > bestScore)
            {
                bestScore = currentScore;
                scoreUI.SetBestScore(currentScore);
            }

            Vector2 screenPosition = Camera.main.WorldToScreenPoint(slicingPosition);
            CreateSceneScore(screenPosition);
        }

        public void CreateSceneScore(Vector2 position)
        {
            SceneScoreUI sceneScore = Instantiate(controllerSettings.SceneScorePrafab, position, Quaternion.identity, canvas);
            sceneScore.InitializeScore(controllerSettings.ScoreValueByOneFruit);
        }
    }
}
