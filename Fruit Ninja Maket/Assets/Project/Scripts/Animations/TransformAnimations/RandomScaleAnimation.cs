using DG.Tweening;
using Project.Scripts.Animations.Abstract;
using UnityEngine;

namespace Project.Scripts.Animations.TransformAnimations
{
    public class RandomScaleAnimation : RandomTransformAnimation
    {
        [SerializeField]
        private float targetIncreaseSize = 1.3f;

        [SerializeField]
        private float targetDecreaseSize = 0.8f;

        [SerializeField]
        private float animationOffsetZ = 1f;
        
        public override void PlayAnimation()
        {
            var duration = GetAnimationDuration();
            var animLerp = GetAnimationLerp();
            var targetSize = Mathf.Lerp(targetDecreaseSize, targetIncreaseSize, animLerp);
            var targetZ = Mathf.Lerp(-animationOffsetZ, animationOffsetZ, animLerp);
            transform.DOScale(targetSize, duration);
            transform.DOMoveZ(targetZ, duration);
        }

        public override void PauseAnimation()
        {
            transform.DOPause();
        }
    }
}