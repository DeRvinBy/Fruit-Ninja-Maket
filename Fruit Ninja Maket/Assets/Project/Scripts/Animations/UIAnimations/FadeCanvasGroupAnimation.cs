using DG.Tweening;
using Scripts.Animations.Abstract;
using UnityEngine;

namespace Scripts.Animations.UIAnimations
{
    public class FadeCanvasGroupAnimation : UICanvasGroupAnimation
    {
        [SerializeField]
        private float targetAlpha = 0f;

        public override void PlayAnimation()
        {
            uiElement.DOFade(targetAlpha, duration);
        }
    }
}
