using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class FruitFactory : SliceBlockFactory
    { 
        [SerializeField]
        private BaseFruitSettings baseFruitSettings = null;

        public override void CreateBlock(Vector2 position, Vector2 direction)
        {
            var prefab = baseFruitSettings.FruitPrefab;
            var go = Instantiate(prefab, position, Quaternion.identity, transform);
            
            var settings = baseFruitSettings.GetRandomFruitSettings();
            go.InitializeFruitSettings(settings);
            go.OnFruitSliced.AddListener(scoreController.AddScoreByFruit);
            go.OnFruitNotSliced.AddListener(lifeController.RemoveLives);
            
            var velocity = direction * baseFruitSettings.VelocityOfObjects;
            InitializeBlock(go, velocity);
        }
    }
}