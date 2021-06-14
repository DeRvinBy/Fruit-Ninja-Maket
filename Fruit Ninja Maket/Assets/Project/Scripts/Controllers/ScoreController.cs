using Scripts.GameSettings.ScoreSettings;
using Scripts.UI;
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

        public void AddScoreByFruit()
        {
            currentScore += controllerSettings.ScoreValueByOneFruit;
            scoreUI.SetCurrentScore(currentScore);
            if(currentScore > bestScore)
            {
                scoreUI.SetBestScore(currentScore);
            }
        }
    }
}
