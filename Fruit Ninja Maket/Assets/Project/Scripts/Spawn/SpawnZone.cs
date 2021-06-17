using System.Collections;
using Project.Scripts.GameSettings.SpawnSettings;
using UnityEngine;

namespace Project.Scripts.Spawn
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

        public void InitializeSpawnObjectsSettings(SpawnObjectsSettings spawnObjectsSettings)
        {
            this.spawnObjectsSettings = spawnObjectsSettings;
        }

        public void InitializeTransformSettings(SpawnZoneTransformSettings transformSettings)
        {
            var camera = Camera.main;
            var topLeftCorner = camera.ScreenToWorldPoint(new Vector2(0, camera.pixelHeight));
            var bottomRightCorner = camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth, 0));
            transform.position = transformSettings.GetRelativePosition(topLeftCorner, bottomRightCorner);
            transform.localScale = transformSettings.GetRelativeScale(topLeftCorner, bottomRightCorner);
        }

        public void SpawnObjectsOnScene()
        {
            var spawnPosition = GetSpawnPosition();
            var direction = GetMovementDirection();
            
            var velocityCoef = spawnObjectsSettings.FromBaseVelocityCoefficient;
            objectCreator.CreateFruit(spawnPosition, direction * velocityCoef);
        }
        
        private Vector2 GetSpawnPosition()
        {
            var lerpCoef = Random.Range(0f, 1f);
            return Vector2.Lerp(startBoundary.position, endBoundary.position, lerpCoef);
        }

        private Vector2 GetMovementDirection()
        {
            var angle = spawnObjectsSettings.DirectionAngle;
            var zoneDirection = (endBoundary.position - startBoundary.position).normalized;
            return (Quaternion.Euler(0, 0, angle) * zoneDirection);
        }
    }
}