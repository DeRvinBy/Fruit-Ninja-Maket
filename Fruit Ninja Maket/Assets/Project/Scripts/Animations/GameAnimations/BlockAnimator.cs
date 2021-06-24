using DG.Tweening;
using Project.Scripts.Animations.AdditionalSettings;
using UnityEngine;
using Animator = Project.Scripts.Animations.Abstract.Animator;

namespace Project.Scripts.Animations.GameAnimations
{
    public class BlockAnimator : Animator
    {
        [SerializeField]
        private float minAngleZ = -360f;
        
        [SerializeField]
        private float maxAngleZ = 360f;
        
        [SerializeField]
        private float targetIncreaseSize = 1.3f;

        [SerializeField]
        private float targetDecreaseSize = 0.8f;

        [SerializeField]
        private float animationOffsetZ = 1f;

        [SerializeField] 
        private RandomAnimationSettings randomSettings = null;

        public override void PlayAnimation()
        {
            var duration = randomSettings.GetAnimationDuration();
            var animLerp = randomSettings.GetAnimationLerp();
            var angles = Vector3.zero;
            angles.z = Mathf.Lerp(minAngleZ, maxAngleZ, animLerp);
            transform.DORotate(angles, duration, RotateMode.FastBeyond360);
            
            var targetSize = Mathf.Lerp(targetDecreaseSize, targetIncreaseSize, animLerp);
            var targetZ = Mathf.Lerp(-animationOffsetZ, animationOffsetZ, animLerp);
            transform.DOScale(targetSize, duration);
            transform.DOMoveZ(targetZ, duration);
        }

        public override void PauseAnimation()
        {
            transform.DOPause();
        }

        public override void PlayReverseAnimation() {}

        public override void CancelAnimation()
        {
            transform.DOKill();
        }
    }
}