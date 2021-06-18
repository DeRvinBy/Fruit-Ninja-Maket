using System;
using Project.Scripts.Spawn;
using UnityEngine;

namespace Project.Scripts.GameSettings.SpawnSettings
{
    [Serializable]
    public class SpawnZonesSettings
    {
        [SerializeField]
        private float probability = 0.0f;

        [SerializeField]
        private SpawnZoneTransformSettings transformSettings = null;

        [SerializeField]
        private SpawnObjectsSettings spawnObjectsSettings = null;

        [SerializeField]
        private SpawnZone spawnZone = null;

        public float Probability { get => probability; set => probability = value; }

        public SpawnZone SpawnZone => spawnZone;

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