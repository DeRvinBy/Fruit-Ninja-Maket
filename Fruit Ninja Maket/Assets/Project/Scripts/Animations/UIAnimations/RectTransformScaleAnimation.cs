using DG.Tweening;
using Scripts.Animations.Abstract;
using UnityEngine;

namespace Scripts.Animations.UIAnimations
{
    public class RectTransformScaleAnimation : UIRectTransformAnimation
    {
        [SerializeField]
        private float targetScale = 1.2f;

        public override void PlayAnimation()
        {
            Vector2 targetSize = rectTransform.localScale * targetScale;
            rectTransform.DOScale(targetSize, duration).SetEase(easeMode);
        }
    }
}
