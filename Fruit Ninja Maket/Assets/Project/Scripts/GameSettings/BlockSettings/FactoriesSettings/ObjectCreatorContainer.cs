using System.Linq;
using Project.Scripts.BlockFactory;
using Project.Scripts.BlockFactory.Abstract;
using Project.Scripts.Extensions;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.FactoriesSettings
{
    public class ObjectCreatorContainer : MonoBehaviour
    {
        [SerializeField] 
        private FactorySettings[] factories = null;

        public BlockFactory.Abstract.BlockFactory GetRandomFactory()
        {
            return factories.GetRandomItemByProbability(x => x.SpawnProbability).BlockFactory;
        }

        public BlockFactory.Abstract.BlockFactory[] GetAllFactories()
        {
            return factories.Select(settings => settings.BlockFactory).ToArray();
        }
    }
}