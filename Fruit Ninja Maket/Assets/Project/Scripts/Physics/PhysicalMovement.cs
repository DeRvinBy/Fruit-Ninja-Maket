using UnityEngine;

namespace Scripts.Physics
{
    public class PhysicalMovement : MonoBehaviour
    {
        [SerializeField]
        private float gravity = 9.8f;

        private readonly Vector2 gravityDirection = Vector2.down;

        private Vector2 velocity;
        
        public void SetVelocity(Vector2 newVelocity)
        {
            velocity += newVelocity;
        }

        private void Update()
        {
            velocity += gravityDirection * gravity; 
            transform.Translate(velocity * Time.deltaTime);
        }
    }
}
