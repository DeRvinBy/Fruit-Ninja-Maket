using Scripts.UI.Lifes;
using UnityEngine;

namespace Scripts.GameSettings.LifesSettings
{
    public class LifesControllerSettings : MonoBehaviour
    {
        [SerializeField] [Range(1, 5)]
        private int maxLifesCount = 5;

        [SerializeField]
        private int incresingLifesValue = 1;

        [SerializeField]
        private SceneFailUI sceneFailPrefab = null;

        public int MaxLifesCount { get => maxLifesCount; }
        public int IncresingLifesValue { get => incresingLifesValue; }
        public SceneFailUI SceneFailPrefab { get => sceneFailPrefab; }
    }
}
