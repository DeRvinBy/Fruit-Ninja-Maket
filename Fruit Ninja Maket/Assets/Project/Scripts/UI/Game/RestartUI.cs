using Project.Scripts.Animations.Abstract;
using TMPro;
using UnityEngine;

namespace Project.Scripts.UI.Game
{
    public class RestartUI : MonoBehaviour
    {
        [SerializeField]
        private UIRectTransformAnimation moveAnimation = null;

        [SerializeField]
        private UICanvasGroupAnimation headerCanvasAnimation = null;

        [SerializeField]
        private UICanvasGroupAnimation backgroundCanvasAnimation = null;

        [SerializeField]
        private TMP_Text currentScoreText = null;

        [SerializeField]
        private TMP_Text bestScoreText = null;

        public void ShowRestartPanel(int currentScore, int bestScore)
        {
            currentScoreText.text = currentScore.ToString();
            bestScoreText.text = bestScore.ToString();
            moveAnimation.PlayAnimation();
            headerCanvasAnimation.PlayAnimation();
            backgroundCanvasAnimation.PlayAnimation();
        }

        public void HideRestartPanel()
        {
            moveAnimation.PlayReverseAnimation();
            headerCanvasAnimation.PlayReverseAnimation();
            backgroundCanvasAnimation.PlayReverseAnimation();
        }
    }
}
