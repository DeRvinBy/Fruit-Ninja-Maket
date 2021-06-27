using DG.Tweening;
using Project.Scripts.Animations.Abstract;
using UnityEngine;
using Animator = Project.Scripts.Animations.Abstract.Animator;

namespace Project.Scripts.Animations.UIAnimations
{
    public class FadeCanvasGroupAnimation : Animator
    {
        [SerializeField]
        private float targetAlpha = 0f;

        [SerializeField] 
        private CanvasGroup uiElement = null;
        
        private float startAlpha;

        private void Start()
        {
            startAlpha = uiElement.alpha;
        }

        public override void PlayAnimation()
        {
            uiElement.DOFade(targetAlpha, duration);
        }

        public override void PauseAnimation()
        {
            uiElement.DOPause();
        }

        public override void PlayReverseAnimation()
        {
            uiElement.DOFade(startAlpha, duration);
        }

        public override void CancelAnimation()
        {
            uiElement.DOKill();
        }
    }
}
