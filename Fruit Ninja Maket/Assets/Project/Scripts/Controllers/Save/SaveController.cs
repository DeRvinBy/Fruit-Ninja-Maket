using UnityEngine;

namespace Project.Scripts.Controllers.Save
{
    public class SaveController : MonoBehaviour
    {
        private const string BestScoreKey = "BestScore";
        public static SaveController Instance {get; private set; }

        public PlayerStats PlayerSave { get; private set; }
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);

                LoadPlayerStats();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnApplicationQuit()
        {
            SavePlayerStats();
        }
        
        private void LoadPlayerStats()
        {
            var score = PlayerPrefs.GetInt(BestScoreKey);
            PlayerSave = new PlayerStats(score);
        }
        
        private void SavePlayerStats()
        {
            PlayerPrefs.SetInt(BestScoreKey, PlayerSave.BestScore);
        }
    }
}
