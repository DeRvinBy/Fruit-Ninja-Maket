using Project.Scripts.BlockFactory.Abstract;
using Project.Scripts.Controllers;
using Project.Scripts.Controllers.Blocks;
using Project.Scripts.Controllers.ModelToView;
using Project.Scripts.GameSettings.BlockSettings;
using Project.Scripts.GameSettings.BlockSettings.FactoriesSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class ObjectCreator : MonoBehaviour
    {
        [SerializeField] 
        private ControllersManager controllersManager;
        
        [SerializeField]
        private ObjectCreatorContainer objectCreatorContainer = null;

        private SliceBlockFactory[] factories;
        
        private void Start()
        {
            factories = objectCreatorContainer.GetAllFactories();
            foreach (var factory in factories)
            {
                factory.Initialize(controllersManager);
            }
        }

        public void SetCountInBundle(int maxCount)
        {
            foreach (var factory in factories)
            {
                factory.SetCountInBundle(maxCount);
            }
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
