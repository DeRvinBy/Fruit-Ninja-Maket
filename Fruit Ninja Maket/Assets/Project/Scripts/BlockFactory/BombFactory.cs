using System;
using Project.Scripts.BlockFactory.Abstract;
using Project.Scripts.Blocks;
using Project.Scripts.Controllers;
using Project.Scripts.Controllers.ModelToView;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using Unity.Mathematics;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public class BombFactory : PercentageBlockFactory
    {
        [SerializeField] 
        private BaseBombSettings bombSettings = null;

        private LifeController lifeController;

        public override void Initialize(ControllersManager manager)
        {
            base.Initialize(manager);
            lifeController = manager.GetLifeController();
        }

        protected override BaseBlockSettings GetBlockSettings()
        {
            return bombSettings;
        }

        protected override SliceBlock CreateBlock(Vector2 position)
        {
            var prefab = bombSettings.Prefab;
            var go = Instantiate(prefab, position, quaternion.identity, transform);
            
            go.InitializeSettings(bombSettings);
            go.OnBombSliced.AddListener(lifeController.RemoveLives);

            return go;
        }
    }
}