using System;
using UnityEngine;

namespace Scripts.Spawn
{
    [Serializable]
    public class SpawnsProbability
    {
        [SerializeField] [Range(0f, 1f)]
        private float probability = 0.0f;

        [SerializeField]
        private SpawnZone spawnZone = null;

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

        public SpawnZone SpawnZone
        {
            get
            {
                return spawnZone;
            }
        }
    }
}