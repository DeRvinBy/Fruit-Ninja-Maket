using System;
using DG.Tweening;
using UnityEngine;

namespace Project.Scripts.Animations.Abstract
{
    public abstract class RectTransformAnimator : Animator
    {
        protected const bool Snapping = true;
        
        [SerializeField] 
        protected RectTransform rectTransform = null;
        
        [SerializeField]
        private Ease easeMode = Ease.Linear;
        
        protected TweenParams tweenParams;

        private void Awake()
        {
            tweenParams = new TweenParams().SetEase(easeMode);
        }

        public override void PauseAnimation()
        {
            rectTransform.DOPause();
        }
        
        public override void CancelAnimation()
        {
            rectTransform.DOKill();
        }
        
        public abstract override void PlayAnimation();

        public abstract override void PlayReverseAnimation();
    }
}