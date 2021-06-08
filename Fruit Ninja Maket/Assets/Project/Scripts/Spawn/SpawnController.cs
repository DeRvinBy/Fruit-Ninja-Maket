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
        private SpawnsSettings[] spawnZones = null;

        private float[] probabilities;

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
            InitializeZones();
            InvokeRepeating(nameof(SpawnObjectsByTime), startSpawnZoneTime, spawnZoneDelay);
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