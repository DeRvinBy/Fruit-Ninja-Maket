using DG.Tweening;
using Project.Scripts.Animations.Abstract;
using UnityEngine;

namespace Project.Scripts.Animations.UIAnimations
{
    public class RectTransformScaleAnimation : RectTransformAnimator
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
            var targetSize = rectTransform.localScale * targetScale;
            rectTransform.DOScale(targetSize, duration).SetAs(tweenParams);
        }

        public override void PlayReverseAnimation()
        {
            rectTransform.DOScale(startScale, duration).SetAs(tweenParams);
        }
    }
}
