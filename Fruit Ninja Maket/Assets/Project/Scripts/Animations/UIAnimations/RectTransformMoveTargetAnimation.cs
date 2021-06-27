using DG.Tweening;
using Project.Scripts.Animations.Abstract;
using UnityEngine;

namespace Project.Scripts.Animations.UIAnimations
{
    public class RectTransformMoveTargetAnimation : RectTransformAnimator
    {
        [SerializeField]
        private Vector2 targetPosition = Vector2.zero;

        private Vector2 startPosition;
        
        private void Start()
        {
            startPosition = rectTransform.anchoredPosition;
            gameObject.SetActive(false);
        }

        public override void PlayAnimation()
        {
            gameObject.SetActive(true);
            rectTransform.DOAnchorPos(targetPosition, duration, Snapping).SetAs(tweenParams);
        }

        public override void PlayReverseAnimation()
        {
            rectTransform.DOAnchorPos(startPosition, duration, Snapping).SetAs(tweenParams).OnComplete(() => gameObject.SetActive(false));
        }
    }
}
