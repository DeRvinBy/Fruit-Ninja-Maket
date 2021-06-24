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
            var gravityMultiplier = physicalSettings.GlobalGravity * mass * deltaTimeWithSlowdown;
            velocity += gravityDirection * gravityMultiplier;
            var translation = velocity * deltaTimeWithSlowdown;
            transform.Translate(translation, Space.World);
        }
    }
}
