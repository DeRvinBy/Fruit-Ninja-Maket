using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Physics
{
    public class PhysicalMovement : MonoBehaviour
    {
        [SerializeField]
        private float gravity = 5f;
        
        private readonly Vector2 gravityDirection = Vector2.down;
        private Vector2 velocity;

        public void AddVelocity(Vector2 newVelocity)
        {
            velocity += newVelocity;
        }

        private void FixedUpdate()
        {
            velocity += gravityDirection * gravity;
        }

        private void Update()
        {
            transform.Translate(velocity * Time.deltaTime, Space.World);
        }
    }
}
