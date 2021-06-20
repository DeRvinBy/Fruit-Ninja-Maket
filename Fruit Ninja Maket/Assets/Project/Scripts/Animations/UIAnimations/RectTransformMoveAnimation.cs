using System;
using DG.Tweening;
using Project.Scripts.Animations.Abstract;
using UnityEngine;

namespace Project.Scripts.Animations.UIAnimations
{
    public class RectTransformMoveAnimation : UIRectTransformAnimation
    {
        [SerializeField]
        private Vector2 targetPosition = Vector2.zero;

        private Vector2 startPosition;

        private void Start()
        {
            startPosition = rectTransform.anchoredPosition;
        }

        public override void PlayAnimation()
        {
            rectTransform.DOAnchorPos(targetPosition, duration, SNAPPING).SetEase(easeMode);
        }

        public override void PlayReverseAnimation()
        {
            rectTransform.DOAnchorPos(startPosition, duration, SNAPPING).SetEase(easeMode);
        }
    }
}
