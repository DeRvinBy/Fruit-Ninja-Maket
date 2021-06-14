using TMPro;
using UnityEngine;

namespace Scripts.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro bestScoreText = null;

        [SerializeField]
        private TextMeshPro currentScoreText = null;

        public void SetBestScore(int value)
        {
            bestScoreText.text = value.ToString();
        }

        public void SetCurrentScore(int value)
        {
            currentScoreText.text = value.ToString();
        }
    }
}
