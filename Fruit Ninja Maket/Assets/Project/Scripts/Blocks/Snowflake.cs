using System.Collections;
using Project.Scripts.Controllers.Blocks;
using Project.Scripts.GameSettings.BlockSettings;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.Blocks
{
    public class Snowflake : SliceBlock
    {
        [SerializeField] 
        private GameObject spriteObject = null;
        
        private BaseSnowflakeSettings snowflakeSettings;
        private PhysicalController physicalController;
        private bool isSlowEffectActive;

        protected override void OnStartBlock()
        {
            base.OnStartBlock();
            physicalController = controllersManager.GetPhysicalController();
        }

        public void InitializeSettings(BaseSnowflakeSettings snowflakeSettings)
        {
            this.snowflakeSettings = snowflakeSettings;
        }
        
        public override void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            
            base.Slice(slicingDirection);
            
            particlesAnimator.PlayParticles();
            StartCoroutine(SlowdownBlocksOnTime());
        }
        
        private IEnumerator SlowdownBlocksOnTime()
        {
            isSlowEffectActive = true;
            physicalController.SetResetSlowdownCoefficient();
            yield return new WaitForSeconds(snowflakeSettings.SlowdownEffectTime);
            physicalController.ResetSlowdownCoefficient();
            isSlowEffectActive = false;
        }
        
        protected override void DisableBlockComponent()
        {
            base.DisableBlockComponent();
            spriteObject.SetActive(false);;
        }

        protected override bool IsCanDestroy()
        {
            var isOutOfBorder = destructionBoundaries.IsOutOfBorder(transform.position);
            var isParticlesCompleted = particlesAnimator.IsParticlesComplete();
            return (isOutOfBorder || isSliced) && !isSlowEffectActive && isParticlesCompleted;
        }
    }
}