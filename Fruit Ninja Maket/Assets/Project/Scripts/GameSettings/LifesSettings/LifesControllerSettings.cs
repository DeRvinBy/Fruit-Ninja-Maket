using UnityEngine;

namespace Scripts.GameSettings.LifesSettings
{
    public class LifesControllerSettings : MonoBehaviour
    {
        [SerializeField] [Range(1, 5)]
        private int maxLifesCount = 5;

        [SerializeField]
        private int incresingLifesValue = 1;

        public int MaxLifesCount { get => maxLifesCount; }
        public int IncresingLifesValue { get => incresingLifesValue; }
    }
}
