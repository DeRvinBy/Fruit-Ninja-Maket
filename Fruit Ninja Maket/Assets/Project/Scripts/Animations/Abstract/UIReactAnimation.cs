using DG.Tweening;
using Scripts.Animations.Interfaces;
using UnityEngine;

namespace Scripts.Animations.Abstract
{
    public abstract class UIReactAnimation : MonoBehaviour, IPlayAnimation
    {
        [SerializeField]
        protected float duration = 1f;

        protected RectTransform rectTransform;

        private void OnEnable()
        {
            rectTransform = (RectTransform)transform;
        }

        public abstract void PlayAnimation();

        private void OnDestroy()
        {
            rectTransform.DOKill();
        }
    }
}
