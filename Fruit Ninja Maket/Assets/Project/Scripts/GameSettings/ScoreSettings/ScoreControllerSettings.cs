using Scripts.UI.Score;
using UnityEngine;

namespace Scripts.GameSettings.ScoreSettings
{
    public class ScoreControllerSettings : MonoBehaviour
    {
        [SerializeField]
        private int scoreValueByOneFruit = 100;

        [SerializeField]
        private SceneScoreUI sceneScorePrefab = null;

        public int ScoreValueByOneFruit { get => scoreValueByOneFruit; }
        public SceneScoreUI SceneScorePrafab { get => sceneScorePrefab; }
    }
}
