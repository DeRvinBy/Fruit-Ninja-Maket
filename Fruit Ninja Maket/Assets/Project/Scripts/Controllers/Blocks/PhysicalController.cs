using Project.Scripts.GameSettings.BlockSettings;
using UnityEngine;

namespace Project.Scripts.Controllers.Blocks
{
    public class PhysicalController : MonoBehaviour
    {
        private const float DefaultSlowdownCoefficient = 1f;
        
        [SerializeField] 
        private PhysicalSettings settings = null;

        private readonly Vector2 gravityDirection = Vector2.down;
        private float slowdownCoefficient = DefaultSlowdownCoefficient;
        private Vector2 magnetPosition;
        
        public bool IsSlowdownEffectActive { get; private set; }
        public bool IsMagnetEffectActive { get; private set; }
        

        public void SetResetSlowdownCoefficient()
        {
            slowdownCoefficient = settings.SlowdownVelocityCoefficient;
            IsSlowdownEffectActive = true;
        }

        public void ResetSlowdownCoefficient()
        {
            slowdownCoefficient = DefaultSlowdownCoefficient;
            IsSlowdownEffectActive = false;
        }

        public void ActivateMagnetAtPosition(Vector2 position)
        {
            IsMagnetEffectActive = true;
            magnetPosition = position;
        }

        public void DeactivateMagnet()
        {
            IsMagnetEffectActive = false;
        }

        public Vector2 GetAttractionVelocity(Vector2 position, Vector2 velocity, float mass)
        {
            var deltaTime = GetDeltaTime();
            var gravityMultiplier = settings.GlobalGravity * mass * deltaTime;
            
            if (IsMagnetEffectActive)
            {
                var distance = magnetPosition - position;
                if ( distance.magnitude < settings.MagnetRadius)
                {
                    var opposingCoef = distance.magnitude / settings.MagnetRadius;
                    var opposingVelocity = velocity * (settings.MagnetVelocity * opposingCoef * deltaTime);
                    var attractionVelocity = distance.normalized * gravityMultiplier;
                    return attractionVelocity - opposingVelocity;
                }
            }
            
            return gravityDirection * gravityMultiplier;
        }

        public float GetDeltaTime()
        {
            return Time.deltaTime * slowdownCoefficient;
        }
    }
}