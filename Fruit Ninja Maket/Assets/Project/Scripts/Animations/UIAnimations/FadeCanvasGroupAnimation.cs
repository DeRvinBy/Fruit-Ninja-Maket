using DG.Tweening;
using Scripts.Animations.Abstract;
using UnityEngine;

namespace Scripts.Animations.UIAnimations
{
    public class FadeCanvasGroupAnimation : UICanvasGroupAnimation
    {
        [SerializeField]
        private float targetAlpha = 0f;

        private float startAlpha;

        private void Start()
        {
            startAlpha = GetComponent<CanvasGroup>().alpha;
        }

        public override void PlayAnimation()
        {
            uiElement.DOFade(targetAlpha, duration);
        }

        public override void PlayReverseAnimation()
        {
            uiElement.DOFade(startAlpha, duration);
        }
    }
}
