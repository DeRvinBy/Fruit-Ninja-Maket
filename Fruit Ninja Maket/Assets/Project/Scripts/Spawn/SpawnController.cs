using System;
using System.Collections;
using Project.Scripts.BlockFactory;
using Project.Scripts.Controllers.ModelToView;
using Project.Scripts.GameSettings.SpawnSettings;
using Project.Scripts.GameSettings.SpawnSettings.MonoSettings;
using UnityEngine;

namespace Project.Scripts.Spawn
{
    public class SpawnController : MonoBehaviour
    {
        [SerializeField] 
        private ObjectCreator objectCreator = null;

        [SerializeField] 
        private ScoreController scoreController = null;
        
        [SerializeField]
        private SpawnControllerSettings controllerSettings = null;

        [SerializeField]
        private SpawnZonesSettingsContainer zonesContainer = null;

        private SpawnDifficultySettings difficultySettings;
        private float currentDelayTimeSpawnNextZone;
        private int baseCountOfSpawningObjects;
        private bool isSpawnObjects;

        private void Start()
        {
            difficultySettings = controllerSettings.DifficultySettings;
        }

        public void Initialize()
        {
            zonesContainer.InitializeZones();
            currentDelayTimeSpawnNextZone = controllerSettings.DelayTimeSpawnNextZone;
            baseCountOfSpawningObjects = 0;
            isSpawnObjects = true;
            StartCoroutine(SpawnObjectsInZone());
        }

        public void StopSpawnObjects()
        {
            isSpawnObjects = false;
            StopCoroutine(SpawnObjectsInZone());
        }

        private IEnumerator SpawnObjectsInZone()
        {
            yield return new WaitForSeconds(controllerSettings.StartTimeOfSpawnZone);

            while (isSpawnObjects)
            {
                var coroutine = SpawnObjectsWithDelay();
                yield return StartCoroutine(coroutine);
                yield return new WaitForSeconds(currentDelayTimeSpawnNextZone);
                IncreaseDifficulty();
            }
        }
        
        private IEnumerator SpawnObjectsWithDelay()
        {
            var count = baseCountOfSpawningObjects + controllerSettings.SpawnObjectsCount;
            objectCreator.SetCountInBundle(count);
            for (int i = 0; i < count && isSpawnObjects; i++)
            {
                var zone = zonesContainer.GetRandomSpawnZoneByProbability();
                zone.SpawnObjectsOnScene();
                yield return new WaitForSeconds(controllerSettings.DelayTimeBetweenSpawnObjects);
            }
        }
        
        private void IncreaseDifficulty()
        {
            var score = scoreController.CurrentScore;
            difficultySettings.UpdateDifficulty(score, ref currentDelayTimeSpawnNextZone, ref baseCountOfSpawningObjects);
        }
    }
}