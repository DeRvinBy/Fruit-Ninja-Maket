using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings
{
    public class PhysicalSettings : MonoBehaviour
    {
        private const float DefaultSlowdownCoefficient = 1f;
        
        [SerializeField] 
        private float globalGravity = 1f;

        public float GlobalGravity => globalGravity;
        public float SlowdownCoefficient { get; private set; } = DefaultSlowdownCoefficient;
        public bool IsSlowdownEffectActive { get; private set; }
        
        public void SetResetSlowdownCoefficient(float value)
        {
            SlowdownCoefficient = value;
            IsSlowdownEffectActive = true;
        }

        public void ResetSlowdownCoefficient()
        {
            SlowdownCoefficient = DefaultSlowdownCoefficient;
            IsSlowdownEffectActive = false;
        }
    }
}