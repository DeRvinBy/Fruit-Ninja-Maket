using Scripts.UI.Score;
using UnityEngine;

namespace Project.Scripts.GameSettings.ScoreSettings
{
    public class ScoreControllerSettings : MonoBehaviour
    {
        [SerializeField]
        private int scoreValueByOneFruit = 100;

        [SerializeField]
        private SceneScoreUI sceneScorePrefab = null;

        public int ScoreValueByOneFruit => scoreValueByOneFruit;
        public SceneScoreUI SceneScorePrefab => sceneScorePrefab;
    }
}
