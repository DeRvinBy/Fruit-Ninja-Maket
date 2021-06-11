using DG.Tweening;
using Scripts.Animations.Abstract;
using UnityEngine;

namespace Scripts.Animations
{
    public class ScaleAnimation : TransformAnimation
    {
        private const int INCREASING_ANIMATION = 0;
        private const int DECREASING_ANIMATION = 1;

        [SerializeField]
        private float targetIncreaseSize = 1.5f;

        [SerializeField]
        private float targetDecreaseSize = 0.7f;

        [SerializeField]
        private float animationOffsetZ = 1f;

        public override void PlayAnimation()
        {
            int animation = Random.Range(INCREASING_ANIMATION, DECREASING_ANIMATION + 1);
            switch (animation)
            {
                case INCREASING_ANIMATION:
                    PlaySizeIncreasingAnimation();
                    break;
                case DECREASING_ANIMATION:
                    PlaySizeDecreasingAnimation();
                    break;
            }
        }

        public override void PauseAnimation()
        {
            transform.DOPause();
        }

        private void PlaySizeIncreasingAnimation()
        {
            transform.DOScale(targetIncreaseSize, duratinon);
            float targetZ = transform.position.z + animationOffsetZ;
            transform.DOMoveZ(targetZ, duratinon);
        }

        private void PlaySizeDecreasingAnimation()
        {
            transform.DOScale(targetDecreaseSize, duratinon);
            float targetZ = transform.position.z - animationOffsetZ;
            transform.DOMoveZ(targetZ, duratinon);
        }
    }
}