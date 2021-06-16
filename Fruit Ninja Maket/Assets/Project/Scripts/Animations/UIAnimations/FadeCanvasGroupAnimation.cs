using DG.Tweening;
using Project.Scripts.Animations.Abstract;
using UnityEngine;

namespace Project.Scripts.Animations.UIAnimations
{
    public class FadeCanvasGroupAnimation : UICanvasGroupAnimation
    {
        [SerializeField]
        private float targetAlpha = 0f;

        private float startAlpha;

        private void Start()
        {
            startAlpha = uiElement.alpha;
        }

        public override void PlayAnimation()
        {
            uiElement.DOFade(targetAlpha, duration);
        }

        public override void PlayReverseAnimation()
        {
            uiElement.DOFade(startAlpha, duration);
        }
    }
}
