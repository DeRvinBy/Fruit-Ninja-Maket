using DG.Tweening;
using Project.Scripts.Animations.Abstract;
using UnityEngine;

namespace Project.Scripts.Animations.TransformAnimations
{
    public class RandomRotateAnimation : RandomTransformAnimation
    {
        [SerializeField]
        private float minAngleZ = -360f;
        
        [SerializeField]
        private float maxAngleZ = 360f;

        public override void PlayAnimation()
        {
            var duration = GetAnimationDuration();
            var animLerp = GetAnimationLerp();
            var angles = Vector3.zero;
            angles.z = Mathf.Lerp(minAngleZ, maxAngleZ, animLerp);
            transform.DORotate(angles, duration, RotateMode.FastBeyond360);
        }

        public override void PauseAnimation()
        {
            transform.DOPause();
        }
    }
}