using DG.Tweening;
using Scripts.Animations.Abstract;
using UnityEngine;

namespace Scripts.Animations.UIAnimations
{
    public class RectTransformMoveAnimation : UIRectTransformAnimation
    {
        [SerializeField]
        private Vector2 offsetDirection = Vector2.zero;

        [SerializeField]
        private float offset = 100f;

        public override void PlayAnimation()
        {
            Vector2 endValue = rectTransform.anchoredPosition + offsetDirection * offset;
            rectTransform.DOAnchorPos(endValue, duration, SNAPPING).SetEase(easeMode);
        }
    }
}
