using Project.Scripts.Blocks;
using Project.Scripts.Controllers.Blocks;
using Project.Scripts.Controllers.ModelToView;
using Project.Scripts.GameSettings.BlockSettings;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.BlockFactory.Abstract
{
    public abstract class SliceBlockFactory : MonoBehaviour
    {
        protected BlockController blockController;
        protected ScoreController scoreController;
        protected LifeController lifeController;
        
        protected PhysicalController physicalController;

        protected int currentBlocksCountInBundle;
        protected int maxBlocksCountInBundle;
        
        public void SetCountInBundle(int maxCountInBundle)
        {
            currentBlocksCountInBundle = 0;
            maxBlocksCountInBundle = maxCountInBundle;
        }

        public void InitializePhysicalSettings(PhysicalController physicalController)
        {
            this.physicalController = physicalController;
        }
        
        public void InitializeControllers(BlockController blockController, ScoreController scoreController,
            LifeController lifeController)
        {
            this.blockController = blockController;
            this.scoreController = scoreController;
            this.lifeController = lifeController;
        }
        
        protected void InitializeBlock(SliceBlock block, Vector2 direction)
        {
            var settings = GetBlockSettings();
            var velocity = direction * settings.VelocityOfBlock;
            block.SetMovement(velocity);
            block.SetPhysicalSettings(physicalController);
            block.SetMass(settings.MassOfBlock);
            blockController.AddBlock(block);
            block.OnBlockDestroyed.AddListener(blockController.RemoveBlock);
        }

        public bool SpawnBlock(Vector2 position, Vector2 direction)
        {
            var isCanCreate = IsCanCreate();
            if (!isCanCreate) return false;
            
            var go = CreateBlock(position);
            InitializeBlock(go, direction);
            currentBlocksCountInBundle++;

            return true;
        }

        protected abstract bool IsCanCreate();
        
        protected abstract BaseBlockSettings GetBlockSettings();

        protected abstract SliceBlock CreateBlock(Vector2 position);
    }
}