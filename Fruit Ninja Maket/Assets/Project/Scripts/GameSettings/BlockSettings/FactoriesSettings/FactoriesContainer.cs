using System.Linq;
using Project.Scripts.BlockFactory;
using Project.Scripts.Extensions;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.FactoriesSettings
{
    public class FactoriesContainer : MonoBehaviour
    {
        [SerializeField] 
        private FactorySettings[] factories = null;

        public SliceBlockFactory GetRandomFactory()
        {
            return factories.GetRandomItemByProbability(x => x.SpawnProbability).BlockFactory;
        }

        public SliceBlockFactory[] GetAllFactories()
        {
            return factories.Select(settings => settings.BlockFactory).ToArray();
        }
    }
}