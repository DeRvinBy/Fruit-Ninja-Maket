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
        
        public float MagnetRadius { get; private set; }
        public Vector2 MagnetPosition { get; private set; }
        public bool IsMagnetEffectActive { get; private set; }

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

        public void ActivateMagnetAtPosition(Vector2 position)
        {
            MagnetRadius = 20f;
            IsMagnetEffectActive = true;
            MagnetPosition = position;
        }

        public void DeactivateMagnet()
        {
            IsMagnetEffectActive = false;
        }
    }
}