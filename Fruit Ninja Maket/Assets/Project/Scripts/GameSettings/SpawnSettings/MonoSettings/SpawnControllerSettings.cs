using UnityEngine;

namespace Scripts.GameSettings.SpawnSettings.MonoSettings
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

        public float StartTimeOfSpawnZone { get => startTimeOfSpawnZone; }
        public float DelayTimeSpawnNextZone { get => delayTimeSpawnNextZone; }
        public float DelayTimeBetweenSpawnObjects { get => delayTimeBetweenSpawnObjects; }
        public float DecreasingValueOfDelayTimeForDifficulty { get => decreasingValueOfDelayTimeForDifficulty; }
        public int IncreasingValueOfCountObjectsForDifficulty { get => increasingValueOfCountObjectsForDifficulty; }
    }
}