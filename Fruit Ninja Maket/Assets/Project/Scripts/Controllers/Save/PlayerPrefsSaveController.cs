using UnityEngine;
using UnityEngine.Events;

namespace Project.Scripts.Controllers.Save
{
    public class PlayerPrefsSaveController : MonoBehaviour, ISaveController
    {
        private const string BestScoreKey = "BestScore";

        public UnityEvent<ISaveController> onCreated = new UnityEvent<ISaveController>();
        
        public PlayerStats PlayerSave { get; private set; }

        private void OnDestroy()
        {
            onCreated?.RemoveAllListeners();
        }

        private void Awake()
        {
            LoadPlayerStats();
            onCreated?.Invoke(this);
        }

        private void OnApplicationQuit()
        {
            if (PlayerSave.IsSaveChanged)
            {
                SavePlayerStats();
            }
        }
        
        public void SavePlayerStats()
        {
            PlayerPrefs.SetInt(BestScoreKey, PlayerSave.BestScore);
        }
        
        private void LoadPlayerStats()
        {
            var score = PlayerPrefs.GetInt(BestScoreKey);
            PlayerSave = new PlayerStats(score);
        }
    }
}
