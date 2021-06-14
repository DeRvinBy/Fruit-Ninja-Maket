using UnityEngine;

namespace Scripts.GameSettings.ScoreSettings
{
    public class ScoreControllerSettings : MonoBehaviour
    {
        [SerializeField]
        private int scoreValueByOneFruit = 100;

        public int ScoreValueByOneFruit { get => scoreValueByOneFruit; }
    }
}
