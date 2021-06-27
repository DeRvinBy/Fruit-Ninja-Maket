using Project.Scripts.Animations.Abstract;
using Project.Scripts.Animations.UIAnimations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI.Game
{
    public class RestartUI : MonoBehaviour
    {
        [SerializeField]
        private RectTransformMoveTargetAnimation moveAnimation = null;

        [SerializeField]
        private FadeCanvasGroupAnimation headerCanvasAnimation = null;

        [SerializeField]
        private FadeCanvasGroupAnimation backgroundCanvasAnimation = null;

        [SerializeField] 
        private Button restartButton = null;
        
        [SerializeField] 
        private Button exitButton = null;

        [SerializeField]
        private TMP_Text currentScoreText = null;

        [SerializeField]
        private TMP_Text bestScoreText = null;

        public void ShowRestartPanel(int currentScore, int bestScore)
        {
            restartButton.interactable = true;
            exitButton.interactable = true;
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
