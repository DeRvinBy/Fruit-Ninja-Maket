using UnityEngine;

namespace Project.Scripts.Physics
{
    public class PhysicalMovement : MonoBehaviour
    {
        [SerializeField] 
        private float gravity = 1f;
        
        private readonly Vector2 gravityDirection = Vector2.down;
        private Vector2 velocity;
        private float mass;

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
            velocity += gravityDirection * (gravity * mass * Time.deltaTime);
            transform.Translate(velocity * Time.deltaTime, Space.World);
        }
    }
}
