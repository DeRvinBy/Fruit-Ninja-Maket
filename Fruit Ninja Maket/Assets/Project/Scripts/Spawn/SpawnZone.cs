using System;
using UnityEngine;

namespace Scripts.Spawn
{
    [Serializable]
    public class SpawnZone
    {
        [SerializeField] [Range(0f, 1f)]
        private float probability = 0.0f;

        [SerializeField] [Range(45f, 135f)]
        private float minDirectionAngle = 45f;

        [SerializeField] [Range(45f, 135f)]
        private float maxDirectionAngle = 135f;

        [SerializeField] [Range(1f, 20f)]
        private float minSpawnObjectsCount = 1f;

        [SerializeField] [Range(1f, 20f)]
        private float maxSpawnObjectsCount = 5f;

        [SerializeField]
        private GameObject[] spawnObjects = null;

        [SerializeField]
        private SpawnBehaviour spawnZone = null;

        public float Probability
        {
            get
            {
                return probability;
            }
            set
            {
                probability = value;
            }
        }
    }
}