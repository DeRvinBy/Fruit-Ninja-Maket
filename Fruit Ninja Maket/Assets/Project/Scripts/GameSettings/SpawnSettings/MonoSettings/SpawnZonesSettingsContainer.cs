using Project.Scripts.Extensions;
using Project.Scripts.Spawn;
using UnityEngine;

namespace Project.Scripts.GameSettings.SpawnSettings.MonoSettings
{
    public class SpawnZonesSettingsContainer : MonoBehaviour
    {
        private const float ProbabilityOfAllZones = 1f;

        [SerializeField]
        private SpawnZonesSettings[] spawnZonesSettings = null;

        private void OnValidate()
        {
            if (spawnZonesSettings.Length == 0) return;

            InitializeZones();
        }

        public void InitializeZones()
        {
            for (int i = 0; i < spawnZonesSettings.Length; i++)
            {
                spawnZonesSettings[i].InitializeSpawnZone();
            }
        }

        public SpawnZone GetRandomSpawnZoneByProbability()
        {
            return spawnZonesSettings.GetRandomItemByProbability(x => x.Probability).SpawnZone;
        }
    }
}