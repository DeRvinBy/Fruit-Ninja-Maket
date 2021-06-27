using System;
using Project.Scripts.BlockFactory;
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

        public SpawnZone SpawnZone => spawnZone;
        public float Probability { get => probability; set => probability = value; }

        public void InitializeSpawnZone()
        {
            spawnZone.Initialize(spawnObjectsSettings);
            spawnZone.SetZonePosition(transformSettings);
        }
    }
}