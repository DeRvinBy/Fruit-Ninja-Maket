using Project.Scripts.Blocks;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using Project.Scripts.GameSettings.BlockSettings.FactoriesSettings;
using Unity.Mathematics;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class BombFactory : SliceBlockFactory
    {
        [SerializeField] 
        private BaseBombSettings bombSettings = null;

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
            return bombSettings;
        }

        protected override SliceBlock CreateBlock(Vector2 position)
        {
            var prefab = bombSettings.Prefab;
            var go = Instantiate(prefab, position, quaternion.identity, transform);
            
            go.InitializeSettings(bombSettings, blockController);
            go.OnBombSliced.AddListener(lifeController.RemoveLives);

            return go;
        }
    }
}