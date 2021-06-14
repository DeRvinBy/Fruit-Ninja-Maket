using UnityEngine;

namespace Scripts.GameSettings.UISettings
{
    public class LifesSettings : MonoBehaviour
    {
        [SerializeField] [Range(1, 5)]
        private int maxLifesCount = 5;

        public int MaxLifesCount { get => maxLifesCount; }
    }
}
