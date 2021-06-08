using Scripts.Physics;
using UnityEngine;

namespace Scripts.Spawn
{
    public class SpawnZone : MonoBehaviour
    {
        [SerializeField]
        private Transform startBoundary = null;

        [SerializeField]
        private Transform endBoundary = null;

        [SerializeField]
        [Range(60f, 120f)]
        private float minDirectionAngle = 60f;

        [SerializeField]
        [Range(60f, 120f)]
        private float maxDirectionAngle = 120f;

        [SerializeField]
        private int minSpawnObjectsCount = 1;

        [SerializeField]
        private int maxSpawnObjectsCount = 5;

        [SerializeField]
        private float startVelocityOfObjects = 20f;

        [SerializeField]
        private GameObject[] spawnObjects = null;

        public void SpawnObjectsOnScene()
        {         
            Vector2 spawnPosition = GetSpawnPosition();
            Vector2 direction = GetMovementDirection();

            Debug.DrawRay(spawnPosition, direction, Color.green, 2f);

            int count = Random.Range(minSpawnObjectsCount, maxSpawnObjectsCount);
            for (int i = 0; i < count; i++)
            {
                int randomIndex = Random.Range(0, spawnObjects.Length);
                var go = Instantiate(spawnObjects[randomIndex], spawnPosition, Quaternion.identity);
                if(go.TryGetComponent(out PhysicalMovement physicalMovement))
                {
                    physicalMovement.SetVelocity(direction * startVelocityOfObjects);
                }
            }
        }

        private Vector2 GetSpawnPosition()
        {
            float lerpCoef = Random.Range(0f, 1f);
            return Vector2.Lerp(startBoundary.position, endBoundary.position, lerpCoef);
        }

        private Vector2 GetMovementDirection()
        {
            float angle = Random.Range(minDirectionAngle, maxDirectionAngle);
            Vector2 zoneDirection = (endBoundary.position - startBoundary.position).normalized;
            return (Quaternion.Euler(0, 0, angle) * zoneDirection);           
        }
    }
}