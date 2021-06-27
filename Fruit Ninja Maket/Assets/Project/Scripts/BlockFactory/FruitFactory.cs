using Project.Scripts.BlockFactory.Abstract;
using Project.Scripts.Blocks;
using Project.Scripts.Controllers;
using Project.Scripts.Controllers.ModelToView;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class FruitFactory : SliceBlockFactory
    { 
        [SerializeField]
        private BaseFruitSettings fruitSettings = null;

        private LifeController lifeController;
        private ScoreController scoreController;
        
        public override void Initialize(ControllersManager manager)
        {
            base.Initialize(manager);
            lifeController = manager.GetLifeController();
            scoreController = manager.GetScoreController();
        }
        
        protected override bool IsCanCreate()
        {
            return true;
        }

        protected override BaseBlockSettings GetBlockSettings()
        {
            return fruitSettings;
        }

        protected override SliceBlock CreateBlock(Vector2 position)
        {
            var prefab = fruitSettings.Prefab;
            var go = Instantiate(prefab, position, Quaternion.identity, transform);
            
            var settings = fruitSettings.GetRandomFruitSettings();
            go.InitializeSettings(settings);
            go.OnFruitSliced.AddListener(scoreController.AddScoreByFruit);
            go.OnFruitNotSliced.AddListener(lifeController.RemoveLivesWithSpawnFail);

            return go;
        }
    }
}