using Scripts.Animations.Abstract;
using TMPro;
using UnityEngine;

namespace Scripts.UI.Score
{
    public class SceneScoreUI : MonoBehaviour
    {
        private const string PLUS_SIGN= "+";

        [SerializeField]
        private float destroyDelay = 2f;

        [SerializeField]
        private TMP_Text scoreText = null;

        [SerializeField]
        private UIRectTransformAnimation moveAnimation = null;

        [SerializeField]
        private UICanvasGroupAnimation canvasGroupAnimation = null;

        public void InitializeScore(int score)
        {
            scoreText.text = PLUS_SIGN + score.ToString();
            moveAnimation.PlayAnimation();
            canvasGroupAnimation.PlayAnimation();
            Destroy(gameObject, destroyDelay);
        }
    }
}