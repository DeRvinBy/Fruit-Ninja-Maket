using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts.Animations.AdditionalSettings
{
    [Serializable]
    public class RandomAnimationSettings
    {
        private const float IncreasingAnimation = 1f;
        private const float DecreasingAnimation = -1f;
        
        [SerializeField]
        private float minDuration = 1f;

        [SerializeField]
        private float maxDuration = 1f;
        
        public float GetAnimationLerp()
        {
            return Random.Range(DecreasingAnimation, IncreasingAnimation);
        }

        public float GetAnimationDuration()
        {
            return Random.Range(minDuration, maxDuration);
        }
    }
}