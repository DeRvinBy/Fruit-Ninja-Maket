using Scripts.Spawn;
using UnityEngine;

namespace Scripts.GameSettings.SpawnSettings.MonoSettings
{
    public class SpawnZonesSettingsContainer : MonoBehaviour
    {
        private const float PROBABILITY_OF_ALL_ZONES = 1f;

        [SerializeField]
        private SpawnZonesSettings[] spawnZonesSettings = null;

        private float[] probabilities;

        private void OnValidate()
        {
            if (spawnZonesSettings.Length != 0)
            {
                float probabilitySum = 0;
                for (int i = 0; i < spawnZonesSettings.Length; i++)
                {
                    if (spawnZonesSettings[i].Probability + probabilitySum <= PROBABILITY_OF_ALL_ZONES)
                    {
                        probabilitySum += spawnZonesSettings[i].Probability;
                    }
                    else
                    {
                        spawnZonesSettings[i].Probability = PROBABILITY_OF_ALL_ZONES - probabilitySum;
                        probabilitySum += spawnZonesSettings[i].Probability;
                    }

                    spawnZonesSettings[i].UpdateSpawnZoneTransform();
                }
            }
        }

        public void InitializeZones()
        {
            probabilities = new float[spawnZonesSettings.Length];

            for (int i = 0; i < probabilities.Length; i++)
            {
                spawnZonesSettings[i].InitializeSpawnZone();
                probabilities[i] = spawnZonesSettings[i].Probability;
            }
        }

        public SpawnZone GetRandomSpawnZoneByProbability()
        {
            float randomPoint = Random.value * PROBABILITY_OF_ALL_ZONES;

            for (int i = 0; i < probabilities.Length; i++)
            {
                if (randomPoint < probabilities[i])
                {
                    return spawnZonesSettings[i].SpawnZone;
                }
                else
                {
                    randomPoint -= probabilities[i];
                }
            }

            return spawnZonesSettings[probabilities.Length - 1].SpawnZone;
        }
    }
}