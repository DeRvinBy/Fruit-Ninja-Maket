using Project.Scripts.Controllers;
using Project.Scripts.Controllers.Blocks;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.Blocks
{
    public class Snowflake : SliceBlock
    {
        [SerializeField] 
        private ParticleSystem snowflakeParticles = null;

        [SerializeField] 
        private GameObject spriteObject = null;
        
        private BaseSnowflakeSettings snowflakeSettings;
        private BlockController blockController;
        
        public void InitializeSettings(BaseSnowflakeSettings snowflakeSettings, BlockController controller)
        {
            this.snowflakeSettings = snowflakeSettings;
            blockController = controller;
        }
        
        public override void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            
            base.Slice(slicingDirection);
            
            snowflakeParticles.Play();
            SlowdownBlocks();
        }
        
        protected void SlowdownBlocks()
        {
            
        }
        
        protected override void DisableBlockComponent()
        {
            base.DisableBlockComponent();
            spriteObject.SetActive(false);;
        }

        protected override bool IsCanDestroy()
        {
            var isOutOfBorder = destructionBoundaries.IsOutOfBorder(transform.position);
            var isParticlesCompleted = !snowflakeParticles.isPlaying;
            return (isOutOfBorder || isSliced) && isParticlesCompleted;
        }
    }
}