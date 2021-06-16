using Scripts.Spawn;
using System;
using UnityEngine;

namespace Scripts.GameSettings.SpawnSettings
{
    [Serializable]
    public class SpawnZonesSettings
    {
        [SerializeField]
        [Range(0f, 1f)]
        private float probability = 0.0f;

        [SerializeField]
        private SpawnZoneTransformSettings transformSettings = null;

        [SerializeField]
        private SpawnObjectsSettings spawnObjectsSettings = null;

        [SerializeField]
        private SpawnZone spawnZone = null;

        public float Probability { get => probability; set => probability = value; }

        public SpawnZone SpawnZone { get => spawnZone; }

        public void InitializeSpawnZone()
        {
            spawnZone.InitializeSpawnObjectsSettings(spawnObjectsSettings);
            UpdateSpawnZoneTransform();
        }

        public void UpdateSpawnZoneTransform()
        {
            spawnZone.InitializeTransformSettings(transformSettings);
        }
    }
}