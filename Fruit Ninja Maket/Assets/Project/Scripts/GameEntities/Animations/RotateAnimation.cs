using DG.Tweening;
using UnityEngine;

namespace Scripts.GameEntities.Animations
{
    public class RotateAnimation : TransformAnimation
    {
        private const int CLOCKWISE_ANIMATION = 0;
        private const int COUNTERCLOCKWISE_ANIMATION = 1;

        [SerializeField]
        private Vector3 angles = Vector3.zero;

        public override void StartAnimation()
        {
            int animation = Random.Range(CLOCKWISE_ANIMATION, COUNTERCLOCKWISE_ANIMATION + 1);
            switch (animation)
            {
                case CLOCKWISE_ANIMATION:
                    PlayClockwiseAnimation();
                    break;
                case COUNTERCLOCKWISE_ANIMATION:
                    PlayCounterclockwiseAnimation();
                    break;
            }
        }

        private void PlayClockwiseAnimation()
        {
            transform.DORotate(angles, duratinon, RotateMode.FastBeyond360);
        }

        private void PlayCounterclockwiseAnimation()
        {
            transform.DORotate(-angles, duratinon, RotateMode.FastBeyond360);
        }
    }
}