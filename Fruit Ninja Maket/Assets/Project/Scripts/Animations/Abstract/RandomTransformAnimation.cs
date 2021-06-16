using DG.Tweening;
using Project.Scripts.Animations.Interfaces;
using UnityEngine;

namespace Project.Scripts.Animations.Abstract
{
    public abstract class RandomTransformAnimation : MonoBehaviour, IPlayAnimation, IPauseAnimation
    {
        private const float IncreasingAnimation = 1f;
        private const float DecreasingAnimation = -1f;
        
        [SerializeField]
        protected float minDuration = 1f;

        [SerializeField]
        protected float maxDuration = 1f;
        
        public abstract void PlayAnimation();

        public abstract void PauseAnimation();

        protected float GetAnimationLerp()
        {
            return Random.Range(DecreasingAnimation, IncreasingAnimation);
        }

        protected float GetAnimationDuration()
        {
            return Random.Range(minDuration, maxDuration);
        }
        
        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}
