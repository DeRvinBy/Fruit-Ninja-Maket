using Project.Scripts.GameSettings.BlockSettings;
using UnityEngine;

namespace Project.Scripts.Physics
{
    public class ObjectCollider : MonoBehaviour
    {
        [Header("Physics settings")]

        [SerializeField] 
        private float colliderRadius = 1f;
        
        [SerializeField]
        protected internal PhysicalMovement physicalMovement = null;

        [SerializeField]
        protected internal bool isEnabledCollider = true;

        public void SetMass(float mass)
        {
            physicalMovement.SetMass(mass);
        }
        
        public void SetPhysicalSettings(PhysicalSettings physicalSettings)
        {
            physicalMovement.SetPhysicalSettings(physicalSettings);
        }
        
        public void SetMovement(Vector2 velocity)
        {
            physicalMovement.AddVelocity(velocity);
        }
        
        public bool IsIntersectWithPoint(Vector2 point)
        {
            if (!isEnabledCollider) return false;
            
            var distance = ((Vector2)transform.position - point).magnitude;
            return distance < colliderRadius;
        }

        public bool IsInRadiusFromPoint(Vector2 point, float radius)
        {
            if (!isEnabledCollider) return false;
            
            var distance = ((Vector2) transform.position - point).magnitude;
            return distance - colliderRadius < radius;
        }
    }
}