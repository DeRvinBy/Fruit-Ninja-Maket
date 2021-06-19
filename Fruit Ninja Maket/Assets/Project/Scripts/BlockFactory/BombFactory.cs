using Project.Scripts.Blocks;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using Unity.Mathematics;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class BombFactory : SliceBlockFactory
    {
        [SerializeField] 
        private BaseBombSettings bombSettings = null;

        protected override bool IsCanCreate()
        {
            return true;
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