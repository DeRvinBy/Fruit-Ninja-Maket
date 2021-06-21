using Project.Scripts.GameSettings.BlockSettings.FactoriesSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory.Abstract
{
    public abstract class PercentageBlockFactory : SliceBlockFactory
    {
        [SerializeField] 
        private PercentageBlocksSettings percentageBlocksSettings = null;
        
        protected override bool IsCanCreate()
        {
            if (percentageBlocksSettings == null) return true;
            
            var percent = (float)currentBlocksCountInBundle / maxBlocksCountInBundle;
            return percent < percentageBlocksSettings.PercentOfBlocksInBundle;
        }
    }
}