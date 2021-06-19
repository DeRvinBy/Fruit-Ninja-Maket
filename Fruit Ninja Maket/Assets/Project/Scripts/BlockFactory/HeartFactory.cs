using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class HeartFactory : SliceBlockFactory
    {
        [SerializeField] 
        private BaseHeartSettings heartSettings = null;

        public override void CreateBlock(Vector2 position, Vector2 direction)
        {
            var prefab = heartSettings.Prefab;
            var go = Instantiate(prefab, position, Quaternion.identity, transform);
            
            go.InitializeSettings(heartSettings);
            go.OnHeartSliced.AddListener(lifeController.AddLives);

            var velocity = direction * heartSettings.VelocityOfBlock;
            InitializeBlock(go, velocity);
        }
    }
}