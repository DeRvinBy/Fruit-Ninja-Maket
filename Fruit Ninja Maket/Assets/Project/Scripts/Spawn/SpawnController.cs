using System.Collections;
using UnityEngine;

namespace Scripts.Spawn
{
    public class SpawnController : MonoBehaviour
    {
        private const float PROBABILITY_OF_ALL_ZONES = 1f;

        [SerializeField]
        private float startTimeOfSpawnZone = 0f;

        [SerializeField]
        private float delayTimeSpawnNextZone = 5f;

        [SerializeField]
        private float delayTimeBetweenSpawnObjects = 0.5f;

        [SerializeField]
        private float decreasingValueOfDelayTimeForDifficulty = 0.5f;

        [SerializeField]
        private int increasingValueOfCountObjectsForDifficulty = 1;

        [SerializeField]
        private SpawnsSettings[] spawnZones = null;

        private float[] probabilities;

        private float currentDelayTimeSpawnNextZone;
        private int baseCountOfSpawningObjects;

        private void OnValidate()
        {
            if (spawnZones.Length != 0)
            {
                float probabilitySum = 0;
                for(int i = 0; i < spawnZones.Length; i++)
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

                InitializeZones();
            }
        }

        private void Start()
        {
            currentDelayTimeSpawnNextZone = delayTimeSpawnNextZone;
            baseCountOfSpawningObjects = 0;
            InitializeZones();
            StartCoroutine(SpawnObjectsByTime());
        }

        public void InitializeZones()
        {
            Camera camera = Camera.main;
            Vector3 topLeftCorner = camera.ScreenToWorldPoint(new Vector2(0, camera.pixelHeight));
            Vector3 bottomRightCorner = camera.ScreenToWorldPoint(new Vector2(camera.pixelWidth, 0));

            probabilities = new float[spawnZones.Length];

            for (int i = 0; i < probabilities.Length; i++)
            {
                spawnZones[i].UpdateZonePositionByScreen(topLeftCorner, bottomRightCorner);
                probabilities[i] = spawnZones[i].Probability;
            }
        }

        private IEnumerator SpawnObjectsByTime()
        {
            yield return new WaitForSeconds(startTimeOfSpawnZone);
            while (true)
            {
                int zoneIndex = GetIndexOfRandomProbability();
                spawnZones[zoneIndex].SpawnZone.SpawnObjectsOnScene(baseCountOfSpawningObjects, delayTimeBetweenSpawnObjects);
                yield return new WaitForSeconds(currentDelayTimeSpawnNextZone);
            }
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

        private void IncreaseDifficulty()
        {
            currentDelayTimeSpawnNextZone -= decreasingValueOfDelayTimeForDifficulty;
            baseCountOfSpawningObjects += increasingValueOfCountObjectsForDifficulty;
        }
    }
}