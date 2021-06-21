using Project.Scripts.UI.Score;
using UnityEngine;

namespace Project.Scripts.GameSettings.ScoreSettings
{
    public class ScoreControllerSettings : MonoBehaviour
    {
        [SerializeField]
        private SceneScoreUI sceneScorePrefab = null;
        
        public SceneScoreUI SceneScorePrefab => sceneScorePrefab;
    }
}
