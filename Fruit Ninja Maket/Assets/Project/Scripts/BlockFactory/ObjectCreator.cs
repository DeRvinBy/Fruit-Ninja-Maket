using System;
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
        private FactoriesContainer factoriesContainer = null;

        private void Start()
        {
            var factories = factoriesContainer.GetAllFactories();
            foreach (var factory in factories)
            {
                factory.InitializeControllers(blockController, scoreController, lifeController);
            }
        }

        public void CreateBlock(Vector2 position, Vector2 direction)
        {
            var factory = factoriesContainer.GetRandomFactory();
            factory.CreateBlock(position, direction);
        }
    }
}
