using DG.Tweening;
using Scripts.Animations.Abstract;
using TMPro;
using UnityEngine;

namespace Scripts.Animations.UIAnimations
{
    public class FadeTextAnimation : UITextAnimation
    {
        [SerializeField]
        private float targetAlpha = 0f;

        public override void PlayAnimation()
        {
            text.DOFade(targetAlpha, duration);
        }
    }
}
