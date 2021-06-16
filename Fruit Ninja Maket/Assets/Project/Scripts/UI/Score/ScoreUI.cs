using TMPro;
using UnityEngine;

namespace Scripts.UI.Score
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text bestScoreText = null;

        [SerializeField]
        private TMP_Text currentScoreText = null;

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
