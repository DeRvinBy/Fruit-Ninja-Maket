using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using Unity.Mathematics;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class BombFactory : SliceBlockFactory
    {
        [SerializeField] 
        private BaseBombSettings bombSettings = null;
        
        public override void CreateBlock(Vector2 position, Vector2 direction)
        {
            var prefab = bombSettings.Prefab;
            var go = Instantiate(prefab, position, quaternion.identity, transform);
            
            go.InitializeSettings(bombSettings, blockController);
            go.OnBombSliced.AddListener(lifeController.RemoveLives);

            var velocity = direction * bombSettings.VelocityOfBlock;
            InitializeBlock(go, velocity);
        }
    }
}