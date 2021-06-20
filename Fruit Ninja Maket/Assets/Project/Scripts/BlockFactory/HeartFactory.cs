using Project.Scripts.Blocks;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using Project.Scripts.GameSettings.BlockSettings.FactoriesSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class HeartFactory : SliceBlockFactory
    {
        [SerializeField] 
        private BaseHeartSettings heartSettings = null;

        [SerializeField] 
        private PercentageBlocksSettings percentageBlocksSettings = null;
        
        protected override bool IsCanCreate()
        {
            if (percentageBlocksSettings == null) return true;

            var percent = (float)currentBlocksCountInBundle / maxBlocksCountInBundle;
            return percent < percentageBlocksSettings.PercentOfBlocksInBundle;
        }

        protected override BaseBlockSettings GetBlockSettings()
        {
            return heartSettings;
        }
        
        protected override SliceBlock CreateBlock(Vector2 position)
        {
            var prefab = heartSettings.Prefab;
            var go = Instantiate(prefab, position, Quaternion.identity, transform);
            
            go.InitializeSettings(heartSettings);
            go.OnHeartSliced.AddListener(lifeController.AddLives);

            return go;
        }
    }
}