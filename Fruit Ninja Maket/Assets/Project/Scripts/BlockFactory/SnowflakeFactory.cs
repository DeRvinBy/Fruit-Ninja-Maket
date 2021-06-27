using Project.Scripts.BlockFactory.Abstract;
using Project.Scripts.Blocks;
using Project.Scripts.Controllers;
using Project.Scripts.Controllers.Blocks;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class SnowflakeFactory : PercentageBlockFactory
    {
        [SerializeField] 
        private BaseSnowflakeSettings snowflakeSettings = null;

        private PhysicalController physicalController;

        public override void Initialize(ControllersManager manager)
        {
            base.Initialize(manager);
            physicalController = manager.GetPhysicalController();
        }

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
            
            go.InitializeSettings(snowflakeSettings);

            return go;
        }
    }
}