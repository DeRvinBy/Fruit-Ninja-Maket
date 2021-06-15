using DG.Tweening;
using Scripts.Animations.Interfaces;
using UnityEngine;

namespace Scripts.Animations.Abstract
{
    public abstract class UIRectTransformAnimation : MonoBehaviour, IPlayAnimation, IReverseAnimation
    {
        protected const bool SNAPPING = true;

        [SerializeField]
        protected float duration = 1f;

        [SerializeField]
        protected Ease easeMode = Ease.Flash;

        protected RectTransform rectTransform;

        private void OnEnable()
        {
            rectTransform = (RectTransform)transform;
        }

        public abstract void PlayAnimation();

        public abstract void PlayReverseAnimation();

        private void OnDestroy()
        {
            rectTransform.DOKill();
        }
    }
}
