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
        private float decreasingValueOfDelayTimeForDifficulty = 0.5f;

        [SerializeField]
        private int increasingValueOfCountObjectsForDifficulty = 1;

        public float StartTimeOfSpawnZone => startTimeOfSpawnZone;
        public float DelayTimeSpawnNextZone => delayTimeSpawnNextZone;
        public float DelayTimeBetweenSpawnObjects => delayTimeBetweenSpawnObjects;
        public float DecreasingValueOfDelayTimeForDifficulty => decreasingValueOfDelayTimeForDifficulty;
        public int IncreasingValueOfCountObjectsForDifficulty => increasingValueOfCountObjectsForDifficulty;
    }
}