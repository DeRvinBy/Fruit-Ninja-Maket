using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts.GameSettings.SpawnSettings
{
    [Serializable]
    public class SpawnObjectsSettings
    {
        [SerializeField]
        [Range(0f, 180f)]
        private float minDirectionAngle = 60f;

        [SerializeField]
        [Range(0f, 180f)]
        private float maxDirectionAngle = 120f;

        [SerializeField] 
        [Range(0f, 1f)] 
        private float fromBaseVelocityCoefficient = 1f;
        
        public float DirectionAngle => Random.Range(minDirectionAngle, maxDirectionAngle);

        public float FromBaseVelocityCoefficient => fromBaseVelocityCoefficient;
    }
}
