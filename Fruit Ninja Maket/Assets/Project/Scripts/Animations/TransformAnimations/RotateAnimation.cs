using DG.Tweening;
using Scripts.Animations.Abstract;
using UnityEngine;

namespace Scripts.Animations.TransformAnimations
{
    public class RotateAnimation : TransformAnimation
    {
        private const int CLOCKWISE_ANIMATION = 0;
        private const int COUNTERCLOCKWISE_ANIMATION = 1;

        [SerializeField]
        private Vector3 angles = Vector3.zero;

        public override void PlayAnimation()
        {
            int animation = Random.Range(CLOCKWISE_ANIMATION, COUNTERCLOCKWISE_ANIMATION + 1);
            switch (animation)
            {
                case CLOCKWISE_ANIMATION:
                    PlayClockwiseAnimation();
                    break;
                case COUNTERCLOCKWISE_ANIMATION:
                    PlayCounterClockwiseAnimation();
                    break;
            }
        }

        public override void PauseAnimation()
        {
            transform.DOPause();
        }

        private void PlayClockwiseAnimation()
        {
            transform.DORotate(angles, duratinon, RotateMode.FastBeyond360);
        }

        private void PlayCounterClockwiseAnimation()
        {
            transform.DORotate(-angles, duratinon, RotateMode.FastBeyond360);
        }
    }
}