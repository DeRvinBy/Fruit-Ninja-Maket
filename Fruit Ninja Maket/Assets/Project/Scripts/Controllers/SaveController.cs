using UnityEngine;

namespace Project.Scripts.Controllers
{
    public class SaveController : MonoBehaviour
    {
        private const string BestScoreKey = "BestScore";
        public static SaveController Instance {get; private set; }

        private int bestGameScore;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);

                bestGameScore = PlayerPrefs.GetInt(BestScoreKey);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public int GetBestScore()
        {
            return bestGameScore;
        }

        public void SetBestScore(int value)
        {
            bestGameScore = value;
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.SetInt(BestScoreKey, bestGameScore);
        }
    }
}
