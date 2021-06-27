using Project.Scripts.BlockFactory.Abstract;
using Project.Scripts.Blocks;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class FruitsBagFactory : PercentageBlockFactory
    {
        [SerializeField] 
        private BaseFruitsBagSettings fruitsBagSettings;

        [SerializeField] 
        private FruitFactory fruitFactory = null;
        
        protected override BaseBlockSettings GetBlockSettings()
        {
            return fruitsBagSettings;
        }

        protected override SliceBlock CreateBlock(Vector2 position)
        {
            var prefab = fruitsBagSettings.Prefab;
            var go = Instantiate(prefab, position, Quaternion.identity, transform);
            
            go.InitializeSettings(fruitsBagSettings, fruitFactory);

            return go;
        }
    }
}