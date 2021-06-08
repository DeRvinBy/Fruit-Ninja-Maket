using UnityEngine;

namespace Scripts.Physics
{
    public class PhysicalMovement : MonoBehaviour
    {
        public float force = 20f;

        [SerializeField]
        private float gravity = 9.8f;

        private readonly Vector2 gravityDirection = Vector2.down;

        private Vector2 velocity;
        

        public void SetVelocity(Vector2 newVelocity)
        {
            velocity += newVelocity;
        }

        private void Start()
        {
            SetVelocity(Vector2.up * force);
        }

        private void Update()
        {
            velocity += gravityDirection * gravity; 
            print(velocity);
            transform.Translate(velocity * Time.deltaTime);
        }
    }
}
