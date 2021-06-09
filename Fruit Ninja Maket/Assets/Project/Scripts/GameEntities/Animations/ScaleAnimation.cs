using DG.Tweening;
using UnityEngine;

namespace Scripts.GameEntities.Animations
{
    public class ScaleAnimation : TransformAnimation
    {
        private const int INCREASING_ANIMATION = 0;
        private const int DECREASING_ANIMATION = 1;

        [SerializeField]
        private float targetScaleUp = 1.5f;

        [SerializeField]
        private float targetScaleDown = 0.7f;

        [SerializeField]
        private float offsetZ = 1f;

        public override void StartAnimation()
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

        private void PlaySizeIncreasingAnimation()
        {
            transform.DOScale(targetScaleUp, duratinon);
            float targetZ = transform.position.z + offsetZ;
            transform.DOMoveZ(targetZ, duratinon);
        }

        private void PlaySizeDecreasingAnimation()
        {
            transform.DOScale(targetScaleDown, duratinon);
            float targetZ = transform.position.z - offsetZ;
            transform.DOMoveZ(targetZ, duratinon);
        }
    }
}