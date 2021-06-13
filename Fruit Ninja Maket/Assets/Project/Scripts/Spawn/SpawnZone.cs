using Scripts.GameSettings.SpawnSettings;
using System.Collections;
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
        private ObjectCreator objectCreator = null;

        private SpawnObjectsSettings spawnObjectsSettings;
        private float verticalWolrdSize;

        public void InitializeSpawnObjectsSettings(SpawnObjectsSettings spawnObjectsSettings)
        {
            this.spawnObjectsSettings = spawnObjectsSettings;
        }

        public void InitializeTransformSettings(SpawnZoneTransformSettings transformSettings)
        {
            Camera camera = Camera.main;
            Vector3 topLeftCorner = camera.ScreenToWorldPoint(new Vector2(0, camera.pixelHeight));
            Vector3 bottomRightCorner = camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth, 0));
            transform.position = transformSettings.GetRelativePosition(topLeftCorner, bottomRightCorner);
            transform.localScale = transformSettings.GetRelativeScale(topLeftCorner, bottomRightCorner);

            verticalWolrdSize = (topLeftCorner.y - bottomRightCorner.y);
        }

        public void SpawnObjectsOnScene(int baseCount, float spawnObjectsDelay)
        {
            StartCoroutine(SpawnObjectsWithDelay(baseCount, spawnObjectsDelay));
        }

        private IEnumerator SpawnObjectsWithDelay(int baseCount, float spawnObjectsDelay)
        {
            Vector2 spawnPosition = GetSpawnPosition();
            Vector2 direction = GetMovementDirection();

            int count = baseCount + spawnObjectsSettings.SpawnObjectsCount;
            for (int i = 0; i < count; i++)
            {
                float velocity = spawnObjectsSettings.BaseVelocityOfObjects / verticalWolrdSize;
                objectCreator.CreateFruit(spawnPosition, direction, velocity);
                yield return new WaitForSeconds(spawnObjectsDelay);
            }
        }

        private Vector2 GetSpawnPosition()
        {
            float lerpCoef = Random.Range(0f, 1f);
            return Vector2.Lerp(startBoundary.position, endBoundary.position, lerpCoef);
        }

        private Vector2 GetMovementDirection()
        {
            float angle = spawnObjectsSettings.DirectionAngle;
            Vector2 zoneDirection = (endBoundary.position - startBoundary.position).normalized;
            return (Quaternion.Euler(0, 0, angle) * zoneDirection);
        }
    }
}