using DG.Tweening;
using Project.Scripts.Animations.Abstract;
using UnityEngine;

namespace Project.Scripts.Animations.UIAnimations
{
    public class RectTransformMoveTargetAnimation : UIRectTransformAnimation
    {
        [SerializeField]
        private Vector2 targetPosition = Vector2.zero;

        private Vector2 startPosition;
        private TweenParams tweenParams;

        private void Start()
        {
            startPosition = rectTransform.anchoredPosition;
            tweenParams = new TweenParams().SetEase(easeMode);
            gameObject.SetActive(false);
        }

        public override void PlayAnimation()
        {
            gameObject.SetActive(true);
            rectTransform.DOAnchorPos(targetPosition, duration, SNAPPING).SetAs(tweenParams);
        }

        public override void PlayReverseAnimation()
        {
            rectTransform.DOAnchorPos(startPosition, duration, SNAPPING).SetAs(tweenParams).OnComplete(() => gameObject.SetActive(false));
        }
    }
}
