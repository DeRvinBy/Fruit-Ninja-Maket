using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class FruitFactory : SliceBlockFactory
    { 
        [SerializeField]
        private BaseFruitSettings fruitSettings = null;

        public override void CreateBlock(Vector2 position, Vector2 direction)
        {
            var prefab = fruitSettings.Prefab;
            var go = Instantiate(prefab, position, Quaternion.identity, transform);
            
            var settings = fruitSettings.GetRandomFruitSettings();
            go.InitializeSettings(settings);
            go.OnFruitSliced.AddListener(scoreController.AddScoreByFruit);
            go.OnFruitNotSliced.AddListener(lifeController.RemoveLivesWithSpawnFail);
            
            var velocity = direction * fruitSettings.VelocityOfBlock;
            InitializeBlock(go, velocity);
        }
    }
}