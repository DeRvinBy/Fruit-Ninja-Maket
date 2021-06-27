using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings
{
    public class PhysicalSettings : MonoBehaviour
    {
        [Header("Global settings")]
        [SerializeField] 
        private float globalGravity = 1f;

        [Header("Slowdown settings")]
        [SerializeField] 
        [Range(0.1f, 1f)] 
        private float slowdownVelocityCoefficient = 0.2f;

        [Header("Magnet settings")] 
        [SerializeField]
        private float magnetRadius = 10f;

        [SerializeField] 
        private float magnetVelocity = 5f;
        
        public float GlobalGravity => globalGravity;
        public float SlowdownVelocityCoefficient => slowdownVelocityCoefficient;
        public float MagnetRadius => magnetRadius;
        public float MagnetVelocity => magnetVelocity;
    }
}