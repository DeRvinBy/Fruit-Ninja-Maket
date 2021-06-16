using Project.Scripts.UI.Life;
using UnityEngine;

namespace Project.Scripts.GameSettings.LifeSettings
{
    public class LifeControllerSettings : MonoBehaviour
    {
        [SerializeField] [Range(1, 5)]
        private int maxLivesCount = 5;

        [SerializeField]
        private int increasingLivesValue = 1;

        [SerializeField]
        private SceneFailUI sceneFailPrefab = null;

        public int MaxLivesCount => maxLivesCount;
        public int IncreasingLivesValue => increasingLivesValue;
        public SceneFailUI SceneFailPrefab => sceneFailPrefab;
    }
}
