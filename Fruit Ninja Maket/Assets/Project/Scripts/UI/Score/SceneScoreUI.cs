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
        private UIReactAnimation moveAnimation = null;

        [SerializeField]
        private UITextAnimation textAnimation = null;

        public void InitializeScore(int score)
        {
            scoreText.text = PLUS_SIGN + score.ToString();
            moveAnimation.PlayAnimation();
            textAnimation.PlayAnimation();
            Destroy(gameObject, destroyDelay);
        }
    }
}