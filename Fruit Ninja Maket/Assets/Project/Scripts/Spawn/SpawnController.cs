using UnityEngine;

namespace Scripts.Spawn
{
    public class SpawnController : MonoBehaviour
    {
        private const float PROBABILITY_OF_ALL_ZONES = 1f;

        [SerializeField]
        private float startSpawnZoneTime = 0f;

        [SerializeField]
        private float spawnZoneDelay = 3f;

        [SerializeField]
        private float spawnObjectsDelay = 0.5f;

        [SerializeField]
        private SpawnsProbability[] spawnZones = null;

        private float[] probabilities;

        private void OnValidate()
        {
            if (spawnZones.Length != 0)
            {
                float probabilitySum = spawnZones[0].Probability;
                for(int i = 1; i < spawnZones.Length; i++)
                {
                    if (spawnZones[i].Probability + probabilitySum <= PROBABILITY_OF_ALL_ZONES)
                    {
                        probabilitySum += spawnZones[i].Probability;
                    }
                    else
                    {
                        spawnZones[i].Probability = PROBABILITY_OF_ALL_ZONES - probabilitySum;
                        probabilitySum += spawnZones[i].Probability;
                    }
                }
            }
        }

        private void Start()
        {
            probabilities = new float[spawnZones.Length];
            for(int i = 0; i < probabilities.Length; i++)
            {
                probabilities[i] = spawnZones[i].Probability;
            }

            InvokeRepeating(nameof(SpawnObjectsByTime), startSpawnZoneTime, spawnZoneDelay);
        }

        private void SpawnObjectsByTime()
        {
            int zoneIndex = GetIndexOfRandomProbability();
            spawnZones[zoneIndex].SpawnZone.SpawnObjectsOnScene(spawnObjectsDelay);
        }

        private int GetIndexOfRandomProbability()
        {
            float randomPoint = Random.value * PROBABILITY_OF_ALL_ZONES;

            for (int i = 0; i < probabilities.Length; i++)
            {
                if (randomPoint < probabilities[i])
                {
                    return i;
                }
                else
                {
                    randomPoint -= probabilities[i];
                }
            }

            return probabilities.Length - 1;
        }
    }
}