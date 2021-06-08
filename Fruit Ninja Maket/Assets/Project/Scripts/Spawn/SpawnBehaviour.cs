using Scripts.Physics;
using UnityEngine;

namespace Scripts.Spawn
{
    public class SpawnBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Transform startBoundary = null;

        [SerializeField]
        private Transform endBoundary = null;

        public void SpawnObjectsOnScene(GameObject[] spawnObjects, float angle)
        {
            float lerpCoef = Random.Range(0f, 1f);
            Vector2 spawnPosition = Vector2.Lerp(startBoundary.position, endBoundary.position, lerpCoef);

            Vector2 skyline = endBoundary.position - startBoundary.position;
            Vector2 direction = Quaternion.Euler(0, 0, angle) * skyline.normalized;
            direction.Normalize();

            Debug.DrawRay(spawnPosition, direction, Color.green, 2f);

            for (int i = 0; i < spawnObjects.Length; i++)
            {
                var go = Instantiate(spawnObjects[i], spawnPosition, Quaternion.identity);
                if(go.TryGetComponent(out PhysicalMovement physicalMovement))
                {
                    physicalMovement.SetVelocity(direction * 25f);
                }
            }
        }
    }
}