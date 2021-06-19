﻿using Project.Scripts.Controllers;
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
        private ObjectCreatorContainer objectCreatorContainer = null;

        private void Start()
        {
            var factories = objectCreatorContainer.GetAllFactories();
            foreach (var factory in factories)
            {
                factory.InitializeControllers(blockController, scoreController, lifeController);
            }
        }

        public void SetCountInBundle(int maxCount)
        {
            objectCreatorContainer.SetCountInBundleToFactories(maxCount);
        }

        public void CreateBlock(Vector2 position, Vector2 direction)
        {
            var isCreateSuccessful = false;
            do
            {
                var factory = objectCreatorContainer.GetRandomFactory();
                isCreateSuccessful = factory.SpawnBlock(position, direction);
            } 
            while (!isCreateSuccessful);
        }
    }
}
