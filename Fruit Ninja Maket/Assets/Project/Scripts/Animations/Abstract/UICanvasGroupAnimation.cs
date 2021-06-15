using DG.Tweening;
using Scripts.Animations.Interfaces;
using UnityEngine;

namespace Scripts.Animations.Abstract
{
    public abstract class UICanvasGroupAnimation : MonoBehaviour, IPlayAnimation
    {
        [SerializeField]
        protected float duration = 1f;

        [SerializeField]
        protected CanvasGroup uiElement = null;

        public abstract void PlayAnimation();

        private void OnDestroy()
        {
            uiElement.DOKill();
        }
    }
}
