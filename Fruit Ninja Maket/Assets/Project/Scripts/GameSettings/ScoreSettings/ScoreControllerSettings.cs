using Project.Scripts.UI.Score;
using UnityEngine;

namespace Project.Scripts.GameSettings.ScoreSettings
{
    public class ScoreControllerSettings : MonoBehaviour
    {
        [SerializeField]
        private SceneScoreUI sceneScorePrefab = null;

        [SerializeField] 
        private int scoreMultiplyCoefficient = 1;

        [SerializeField] 
        private float maxTimeToIncreaseCombo = 1.5f;
        
        [SerializeField] 
        private int maxScoreCombo = 5;
        
        public SceneScoreUI SceneScorePrefab => sceneScorePrefab;

        public int ScoreMultiplyCoefficient => scoreMultiplyCoefficient;

        public float MaxTimeToIncreaseCombo => maxTimeToIncreaseCombo;

        public int MaxScoreCombo => maxScoreCombo;
    }
}
