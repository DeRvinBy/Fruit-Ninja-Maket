using System.Collections;
using Project.Scripts.GameSettings.SpawnSettings.MonoSettings;
using UnityEngine;

namespace Project.Scripts.Spawn
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField]
        private SpawnControllerSettings controllerSettings = null;

        [SerializeField]
        private SpawnZonesSettingsContainer zonesContainer = null;

        private float currentDelayTimeSpawnNextZone;
        private int baseCountOfSpawningObjects;
        private bool isSpawnObjects;

        public void Initialize()
        {
            zonesContainer.InitializeZones();
            currentDelayTimeSpawnNextZone = controllerSettings.DelayTimeSpawnNextZone;
            baseCountOfSpawningObjects = 0;
            isSpawnObjects = true;
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
                var zone = zonesContainer.GetRandomSpawnZoneByProbability();
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