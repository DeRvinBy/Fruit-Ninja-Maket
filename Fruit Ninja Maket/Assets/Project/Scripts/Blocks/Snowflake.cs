using System.Collections;
using Project.Scripts.Controllers;
using Project.Scripts.Controllers.Blocks;
using Project.Scripts.GameSettings.BlockSettings;
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
        private PhysicalSettings physicalSettings;
        private bool isSlowEffectActive;
        
        public void InitializeSettings(BaseSnowflakeSettings snowflakeSettings, PhysicalSettings physicalSettings)
        {
            this.snowflakeSettings = snowflakeSettings;
            this.physicalSettings = physicalSettings;
        }
        
        public override void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            
            base.Slice(slicingDirection);
            
            snowflakeParticles.Play();
            StartCoroutine(SlowdownBlocksOnTime());
        }
        
        private IEnumerator SlowdownBlocksOnTime()
        {
            isSlowEffectActive = true;
            physicalSettings.SetResetSlowdownCoefficient(snowflakeSettings.SlowdownVelocityCoefficient);
            yield return new WaitForSeconds(snowflakeSettings.FreezeTime);
            physicalSettings.ResetSlowdownCoefficient();
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
            var isParticlesCompleted = !snowflakeParticles.isPlaying;
            return (isOutOfBorder || isSliced) && !isSlowEffectActive && isParticlesCompleted;
        }
    }
}