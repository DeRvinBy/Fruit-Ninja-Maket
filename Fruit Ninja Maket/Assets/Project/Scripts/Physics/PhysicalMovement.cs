using UnityEngine;

namespace Project.Scripts.Physics
{
    public class PhysicalMovement : MonoBehaviour
    {
        private readonly Vector2 gravityDirection = Vector2.down;
        private Vector2 velocity;
        private float gravity;

        public void SetGravity(float gravity)
        {
            this.gravity = gravity;
        }
        
        public void AddVelocity(Vector2 newVelocity)
        {
            velocity += newVelocity;
        }

        private void Update()
        {
            velocity += gravityDirection * gravity * Time.deltaTime;
            transform.Translate(velocity * Time.deltaTime, Space.World);
        }
    }
}
