using Project.Scripts.Blocks;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class HeartFactory : SliceBlockFactory
    {
        [SerializeField] 
        private BaseHeartSettings heartSettings = null;

        protected override bool IsCanCreate()
        {
            return true;
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