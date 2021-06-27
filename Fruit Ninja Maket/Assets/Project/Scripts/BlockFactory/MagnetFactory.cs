using Project.Scripts.BlockFactory.Abstract;
using Project.Scripts.Blocks;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class MagnetFactory : PercentageBlockFactory
    {
        [SerializeField] 
        private BaseMagnetSettings magnetSettings = null;

        protected override bool IsCanCreate()
        {
            var result = base.IsCanCreate();

            return result && !physicalSettings.IsMagnetEffectActive;
        }
        
        protected override BaseBlockSettings GetBlockSettings()
        {
            return magnetSettings;
        }

        protected override SliceBlock CreateBlock(Vector2 position)
        {
            var prefab = magnetSettings.Prefab;
            var go = Instantiate(prefab, position, Quaternion.identity, transform);
            
            go.InitializeSettings(magnetSettings, physicalSettings);

            return go;
        }
    }
}