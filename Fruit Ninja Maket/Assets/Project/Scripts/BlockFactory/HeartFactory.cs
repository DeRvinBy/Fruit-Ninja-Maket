using Project.Scripts.BlockFactory.Abstract;
using Project.Scripts.Blocks;
using Project.Scripts.Controllers;
using Project.Scripts.Controllers.ModelToView;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class HeartFactory : PercentageBlockFactory
    {
        [SerializeField] 
        private BaseHeartSettings heartSettings = null;

        private LifeController lifeController;

        public override void Initialize(ControllersManager manager)
        {
            base.Initialize(manager);
            lifeController = manager.GetLifeController();
        }

        protected override bool IsCanCreate()
        {
            var result = base.IsCanCreate();

            return result && !lifeController.IsFullLives;
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
            go.OnHeartSliced.AddListener(lifeController.AddLivesAnimate);

            return go;
        }
    }
}