using Scripts.GameSettings.SpawnSettings;
using Scripts.Spawn;
using UnityEngine;

namespace Project.Scripts.GameSettings.SpawnSettings.MonoSettings
{
    public class SpawnZonesSettingsContainer : MonoBehaviour
    {
        private const float ProbabilityOfAllZones = 1f;

        [SerializeField]
        private SpawnZonesSettings[] spawnZonesSettings = null;

        private float[] probabilities;

        private void OnValidate()
        {
            if (spawnZonesSettings.Length == 0) return;
            
            float probabilitySum = 0;
            foreach (var spawnZone in spawnZonesSettings)
            {
                if (spawnZone.Probability + probabilitySum <= ProbabilityOfAllZones)
                {
                    probabilitySum += spawnZone.Probability;
                }
                else
                {
                    spawnZone.Probability = ProbabilityOfAllZones - probabilitySum;
                    probabilitySum += spawnZone.Probability;
                }

                spawnZone.UpdateSpawnZoneTransform();
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
            var randomPoint = Random.value * ProbabilityOfAllZones;

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