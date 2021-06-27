using Project.Scripts.Controllers.Blocks;
using Project.Scripts.GameSettings.BlockSettings;
using UnityEngine;

namespace Project.Scripts.Physics
{
    public class PhysicalMovement : MonoBehaviour
    {
        private PhysicalController physicalController;
        private Vector2 velocity;
        private float mass;
        private bool isMagnet;
        
        public void Initialize(PhysicalController physicalController)
        {
            this.physicalController = physicalController;
        }
        
        public void SetMass(float mass)
        {
            this.mass = mass;
        }

        public void AddVelocity(Vector2 newVelocity)
        {
            velocity += newVelocity;
        }

        private void Update()
        {
            var attractionVelocity = physicalController.GetAttractionVelocity(transform.position, velocity, mass);
            velocity += attractionVelocity;
            var translation = velocity * physicalController.GetDeltaTime();
            transform.Translate(translation, Space.World);
        }
    }
}
