using Project.Scripts.GameSettings.BlockSettings;
using UnityEngine;

namespace Project.Scripts.Physics
{
    public class PhysicalMovement : MonoBehaviour
    {
        private readonly Vector2 gravityDirection = Vector2.down;
        private PhysicalSettings physicalSettings;
        private Vector2 velocity;
        private float mass;
        private bool isMagnet;
        
        public void SetMass(float mass)
        {
            this.mass = mass;
        }
        
        public void SetPhysicalSettings(PhysicalSettings physicalSettings)
        {
            this.physicalSettings = physicalSettings;
        }
        
        public void AddVelocity(Vector2 newVelocity)
        {
            velocity += newVelocity;
        }

        private void Update()
        {
            var deltaTimeWithSlowdown = Time.deltaTime * physicalSettings.SlowdownCoefficient;
            var attractionVelocity = GetAttractionVelocity(deltaTimeWithSlowdown);
            velocity += attractionVelocity;
            var translation = velocity * deltaTimeWithSlowdown;
            transform.Translate(translation, Space.World);
        }

        private Vector2 GetAttractionVelocity(float deltaTime)
        {
            var gravityMultiplier = physicalSettings.GlobalGravity * mass * deltaTime;
            
            if (physicalSettings.IsMagnetEffectActive)
            {
                var distance = physicalSettings.MagnetPosition - (Vector2) transform.position;
                if (distance.magnitude < physicalSettings.MagnetRadius)
                {
                    var coef = distance.magnitude / physicalSettings.MagnetRadius;
                    return distance.normalized * (gravityMultiplier) - velocity * 5f * coef * deltaTime;
                }
            }
            
            return gravityDirection * gravityMultiplier;
        }
    }
}
