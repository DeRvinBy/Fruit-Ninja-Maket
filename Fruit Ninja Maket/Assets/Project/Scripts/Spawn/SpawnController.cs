using UnityEngine;

namespace Scripts.Spawn
{
    public class SpawnController : MonoBehaviour
    {
        private const float PROBABILITY_OF_ALL_ZONES = 1f;

        [SerializeField]
        private float spawnDelay = 1f;

        [SerializeField]
        private SpawnsProbability[] spawnZones = null;

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
            InvokeRepeating(nameof(SpawnObjectsByTime), 0f, spawnDelay);
        }

        private void SpawnObjectsByTime()
        {
            spawnZones[2].SpawnZone.SpawnObjectsOnScene();
        }
    }
}