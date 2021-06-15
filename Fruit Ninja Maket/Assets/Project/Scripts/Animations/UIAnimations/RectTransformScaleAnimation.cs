using DG.Tweening;
using Scripts.Animations.Abstract;
using UnityEngine;

namespace Scripts.Animations.UIAnimations
{
    public class RectTransformScaleAnimation : UIRectTransformAnimation
    {
        [SerializeField]
        private float targetScale = 1.2f;

        private Vector2 startScale;

        private void Start()
        {
            startScale = rectTransform.localScale;
        }

        public override void PlayAnimation()
        {
            Vector2 targetSize = rectTransform.localScale * targetScale;
            rectTransform.DOScale(targetSize, duration).SetEase(easeMode);
        }

        public override void PlayReverseAnimation()
        {
            rectTransform.DOScale(startScale, duration).SetEase(easeMode);
        }
    }
}
