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
        private ScoreUI scoreUI = null;

        [SerializeField]
        private Transform UI = null;

        private int bestScore = 200;
        private int currentScore;

        public void Start()
        {
            currentScore = 0;
            scoreUI.SetBestScore(bestScore);
        }

        public void AddScoreByFruit(Vector2 slicingPosition)
        {
            currentScore += controllerSettings.ScoreValueByOneFruit;
            scoreUI.SetCurrentScore(currentScore);
            if(currentScore > bestScore)
            {
                scoreUI.SetBestScore(currentScore);
            }

            var screenPosition = Camera.main.WorldToScreenPoint(slicingPosition);
            CreateSceneScore(screenPosition);
        }

        public void CreateSceneScore(Vector2 position)
        {
            SceneScoreUI sceneScore = Instantiate(controllerSettings.SceneScorePrafab, position, Quaternion.identity, UI);
            sceneScore.InitializeScore(controllerSettings.ScoreValueByOneFruit);
        }
    }
}
