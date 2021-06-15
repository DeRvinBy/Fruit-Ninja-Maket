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

            Vector2 screenPosition = Camera.main.WorldToScreenPoint(slicingPosition);
            CreateSceneScore(screenPosition);
        }

        public void CreateSceneScore(Vector2 position)
        {
            SceneScoreUI sceneScore = Instantiate(controllerSettings.SceneScorePrafab, position, Quaternion.identity, scoreUI.transform.parent);
            sceneScore.InitializeScore(controllerSettings.ScoreValueByOneFruit);
        }
    }
}
