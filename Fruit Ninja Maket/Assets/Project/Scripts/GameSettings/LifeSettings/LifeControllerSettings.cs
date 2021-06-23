using Project.Scripts.UI.Life;
using UnityEngine;

namespace Project.Scripts.GameSettings.LifeSettings
{
    public class LifeControllerSettings : MonoBehaviour
    {
        [SerializeField]
        [Min(1)]
        private int maxLivesCount = 5;

        [SerializeField]
        private SceneFailUI sceneFailPrefab = null;

        [SerializeField] 
        private LifeContainerUI lifeContainerPrefab = null;

        public int MaxLivesCount => maxLivesCount;
        public SceneFailUI SceneFailPrefab => sceneFailPrefab;

        public LifeContainerUI LifeContainerPrefab => lifeContainerPrefab;
    }
}
