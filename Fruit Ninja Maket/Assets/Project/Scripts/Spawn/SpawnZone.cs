using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.Spawn
{
    [Serializable]
    public class SpawnZone
    {
        [SerializeField] [Range(0f, 1f)]
        private float probability = 0.0f;

        [SerializeField] [Range(60f, 120f)]
        private float minDirectionAngle = 45f;

        [SerializeField] [Range(60f, 120f)]
        private float maxDirectionAngle = 135f;

        [SerializeField] [Range(1, 20)]
        private int minSpawnObjectsCount = 1;

        [SerializeField] [Range(1, 20)]
        private int maxSpawnObjectsCount = 5;

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

        public void SpawnObjects()
        {
            float angle = Random.Range(minDirectionAngle, maxDirectionAngle);
            int count = Random.Range(minSpawnObjectsCount, maxSpawnObjectsCount);
            GameObject[] randomSpawnObjects = new GameObject[count];
            for(int i = 0; i < count; i++)
            {
                int randomIndex = Random.Range(0, spawnObjects.Length);
                randomSpawnObjects[i] = spawnObjects[randomIndex];
            }
            spawnZone.SpawnObjectsOnScene(randomSpawnObjects, angle);
        }
    }
}