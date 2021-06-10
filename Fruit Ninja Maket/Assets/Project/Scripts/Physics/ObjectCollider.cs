using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Physics
{
    public class ObjectCollider : MonoBehaviour
    {
        [SerializeField]
        private float radius = 1f;

        private static List<ObjectCollider> colliders = new List<ObjectCollider>();

        private void Start()
        {
            colliders.Add(this);
        }

        private void OnDestroy()
        {
            colliders.Remove(this);
        }

        public static List<GameObject> GetObjectIntersectedWithPoint(Vector2 point)
        {
            List<GameObject> result = new List<GameObject>();
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
            float distance = ((Vector2)transform.position - point).magnitude;
            return distance < radius;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}