using System.Linq;
using Project.Scripts.BlockFactory;
using Project.Scripts.Blocks;
using Project.Scripts.Extensions;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.FactoriesSettings
{
    public class ObjectCreatorSettings : MonoBehaviour
    {
        private const int MaxIterationToFindFactory = 100;
        
        [SerializeField] 
        private FactorySettings[] factories = null;

        public SliceBlockFactory GetRandomFactory()
        {
            SliceBlockFactory factory = null;
            int i = 0;
            do
            {
                var settings = factories.GetRandomItemByProbability(x => x.SpawnProbability);
                factory = settings.GetBlockFactoryByCountInBundle();
                i++;
            } 
            while (factory == null && i < MaxIterationToFindFactory);

            return factory;
        }

        public void SetCountInBundleToFactories(int maxCount)
        {
            foreach (var factory in factories)
            {
                factory.SetCountInBundle(maxCount);
            }
        }

        public SliceBlockFactory[] GetAllFactories()
        {
            return factories.Select(settings => settings.BlockFactory).ToArray();
        }
    }
}