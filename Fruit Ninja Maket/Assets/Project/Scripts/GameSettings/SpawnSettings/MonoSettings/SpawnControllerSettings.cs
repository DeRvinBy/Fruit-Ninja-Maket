using UnityEngine;

namespace Project.Scripts.GameSettings.SpawnSettings.MonoSettings
{
    public class SpawnControllerSettings : MonoBehaviour
    {
        [SerializeField]
        private float startTimeOfSpawnZone = 0f;

        [SerializeField]
        private float delayTimeSpawnNextZone = 5f;

        [SerializeField]
        private float delayTimeBetweenSpawnObjects = 0.5f;
        
        [SerializeField]
        private int minSpawnObjectsCount = 1;

        [SerializeField]
        private int maxSpawnObjectsCount = 5;

        [SerializeField] 
        private SpawnDifficultySettings difficultySettings = null;
        
        public float StartTimeOfSpawnZone => startTimeOfSpawnZone;
        public float DelayTimeSpawnNextZone => delayTimeSpawnNextZone;
        public float DelayTimeBetweenSpawnObjects => delayTimeBetweenSpawnObjects;
        public int SpawnObjectsCount => Random.Range(minSpawnObjectsCount, maxSpawnObjectsCount);

        public SpawnDifficultySettings DifficultySettings => difficultySettings;
    }
}