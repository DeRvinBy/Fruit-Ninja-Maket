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
        public SceneScoreUI SceneScorePrefab => sceneScorePrefab;

        public int ScoreMultiplyCoefficient => scoreMultiplyCoefficient;
    }
}
