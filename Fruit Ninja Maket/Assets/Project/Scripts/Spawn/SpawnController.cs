using Scripts.GameSettings.SpawnSettings.MonoSettings;
using System.Collections;
using UnityEngine;

namespace Scripts.Spawn
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField]
        private SpawnControllerSettings controllerSettings = null;

        [SerializeField]
        private SpawnZonesSettingsContainer zonesContainer = null;

        private float currentDelayTimeSpawnNextZone;
        private int baseCountOfSpawningObjects;

        private bool isSpawnObjects = true;

        private void Start()
        {
            currentDelayTimeSpawnNextZone = controllerSettings.DelayTimeSpawnNextZone;
            baseCountOfSpawningObjects = 0;
            zonesContainer.InitializeZones();
            StartCoroutine(SpawnObjectsByTime());
        }

        public void StopSpawnObjects()
        {
            isSpawnObjects = false;
            StopCoroutine(SpawnObjectsByTime());
        }

        private IEnumerator SpawnObjectsByTime()
        {
            yield return new WaitForSeconds(controllerSettings.StartTimeOfSpawnZone);

            while (isSpawnObjects)
            {
                SpawnZone zone = zonesContainer.GetRandomSpawnZoneByProbability();
                zone.SpawnObjectsOnScene(baseCountOfSpawningObjects, controllerSettings.DelayTimeBetweenSpawnObjects);
                yield return new WaitForSeconds(currentDelayTimeSpawnNextZone);
            }
        }

        private void IncreaseDifficulty()
        {
            currentDelayTimeSpawnNextZone -= controllerSettings.DecreasingValueOfDelayTimeForDifficulty;
            baseCountOfSpawningObjects += controllerSettings.IncreasingValueOfCountObjectsForDifficulty;
        }
    }
}