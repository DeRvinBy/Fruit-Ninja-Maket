using DG.Tweening;
using Project.Scripts.Animations.Abstract;
using UnityEngine;

namespace Project.Scripts.Animations.UIAnimations
{
    public class RectTransformMoveOffsetAnimation : RectTransformAnimator
    {
        [SerializeField]
        private Vector2 offsetDirection = Vector2.zero;

        [SerializeField]
        private float offset = 100f;

        private Vector2 startPosition;

        private void Start()
        {
            startPosition = rectTransform.anchoredPosition;
        }

        public override void PlayAnimation()
        {
            var endValue = rectTransform.anchoredPosition + offsetDirection * offset;
            rectTransform.DOAnchorPos(endValue, duration, Snapping).SetAs(tweenParams);
        }
        
        public override void PlayReverseAnimation()
        {
            rectTransform.DOAnchorPos(startPosition, duration, Snapping).SetAs(tweenParams);
        }
    }
}