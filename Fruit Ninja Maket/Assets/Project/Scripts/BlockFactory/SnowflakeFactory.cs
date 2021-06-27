using Project.Scripts.BlockFactory.Abstract;
using Project.Scripts.Blocks;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using Unity.Mathematics;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class SnowflakeFactory : PercentageBlockFactory
    {
        [SerializeField] 
        private BaseSnowflakeSettings snowflakeSettings = null;

        protected override bool IsCanCreate()
        {
            var result = base.IsCanCreate();

            return result && !physicalController.IsSlowdownEffectActive;
        }

        protected override BaseBlockSettings GetBlockSettings()
        {
            return snowflakeSettings;
        }

        protected override SliceBlock CreateBlock(Vector2 position)
        {
            var prefab = snowflakeSettings.Prefab;
            var go = Instantiate(prefab, position, Quaternion.identity, transform);
            
            go.InitializeSettings(snowflakeSettings, physicalController);

            return go;
        }
    }
}