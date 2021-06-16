using DG.Tweening;
using Scripts.Animations.Abstract;
using UnityEngine;

namespace Scripts.Animations.SpriteRendererAnimations
{
    public class FadeAnimation : SpriteRendererAnimation
    {
        [SerializeField]
        private float targetAlpha = 0f;

        public override void PlayAnimation(float time)
        {
            spriteRenderer.DOFade(targetAlpha, time);
        }
    }
}
