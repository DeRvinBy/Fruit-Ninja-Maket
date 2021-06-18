using Project.Scripts.Controllers;
using Project.Scripts.GameSettings.BlockSettings.FactoriesSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class ObjectCreator : MonoBehaviour
    {
        [SerializeField] 
        private BlockController blockController = null;
        
        [SerializeField]
        private ScoreController scoreController = null;

        [SerializeField]
        private LifeController lifeController = null;

        [SerializeField]
        private ObjectCreatorSettings objectCreatorSettings = null;

        private void Start()
        {
            var factories = objectCreatorSettings.GetAllFactories();
            foreach (var factory in factories)
            {
                factory.InitializeControllers(blockController, scoreController, lifeController);
            }
        }

        public void SetCountInBundle(int maxCount)
        {
            objectCreatorSettings.SetCountInBundleToFactories(maxCount);
        }

        public void CreateBlock(Vector2 position, Vector2 direction)
        {
            var factory = objectCreatorSettings.GetRandomFactory();
            factory.CreateBlock(position, direction);
        }
    }
}
