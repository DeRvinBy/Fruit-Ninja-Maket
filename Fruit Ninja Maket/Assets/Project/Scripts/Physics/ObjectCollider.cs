using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Physics
{
    public class ObjectCollider : MonoBehaviour
    {
        private static List<ObjectCollider> colliders = new List<ObjectCollider>();

        [SerializeField]
        private float radius = 1f;

        private void Start()
        {
            colliders.Add(this);
        }

        private void OnDestroy()
        {
            colliders.Remove(this);
        }

        public static List<GameObject> GetObjectsIntersectedWithPoint(Vector2 point)
        {
            var result = new List<GameObject>();
            foreach(var collider in colliders)
            {
                if(collider.IsIntersectWithPoint(point))
                {
                    result.Add(collider.gameObject);
                }
            }
            return result;
        }

        private bool IsIntersectWithPoint(Vector2 point)
        {
            var distance = ((Vector2)transform.position - point).magnitude;
            return distance < radius;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}