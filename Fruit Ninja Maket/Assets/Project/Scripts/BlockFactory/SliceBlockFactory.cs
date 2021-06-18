using Project.Scripts.Blocks;
using Project.Scripts.Controllers;
using UnityEngine;

namespace Project.Scripts.BlockFactory
{
    public abstract class SliceBlockFactory : MonoBehaviour
    {
        private BlockController blockController;
        protected ScoreController scoreController;
        protected LifeController lifeController;
        
        public void InitializeControllers(BlockController blockController, ScoreController scoreController,
            LifeController lifeController)
        {
            this.blockController = blockController;
            this.scoreController = scoreController;
            this.lifeController = lifeController;
        }
        
        protected void InitializeBlock(SliceBlock block, Vector2 velocity)
        {
            block.SetMovement(velocity);
            blockController.AddBlock(block);
            block.OnBlockDestroyed.AddListener(blockController.RemoveBlock);
        }
        
        public abstract void CreateBlock(Vector2 position, Vector2 direction);
    }
}