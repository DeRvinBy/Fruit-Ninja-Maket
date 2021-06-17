using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Physics
{
    public abstract class ObjectCollider : MonoBehaviour
    {
        [SerializeField] 
        private float colliderRadius = 1f;

        public bool IsIntersectWithPoint(Vector2 point)
        {
            var distance = ((Vector2)transform.position - point).magnitude;
            return distance < colliderRadius;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, colliderRadius);
        }
    }
}