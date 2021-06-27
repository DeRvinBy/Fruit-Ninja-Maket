using System.Collections;
using Project.Scripts.GameSettings.BlockSettings;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.Blocks
{
    public class Magnet : SliceBlock
    {
        private BaseMagnetSettings magnetSettings;
        private PhysicalSettings physicalSettings;
        private bool isMagnetEffectActive;

        public void InitializeSettings(BaseMagnetSettings magnetSettings, PhysicalSettings physicalSettings)
        {
            this.magnetSettings = magnetSettings;
            this.physicalSettings = physicalSettings;
        }
        
        public override void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            
            base.Slice(slicingDirection);
            
            particlesAnimator.PlayParticles();
            StartCoroutine(ActivateMagnetOnTime());
        }
        
        private IEnumerator ActivateMagnetOnTime()
        {
            isMagnetEffectActive = true;
            physicalSettings.ActivateMagnetAtPosition(transform.position);
            yield return new WaitForSeconds(magnetSettings.MagnetEffectTime);
            physicalSettings.DeactivateMagnet();
            isMagnetEffectActive = false;
        }
        
        protected override bool IsCanDestroy()
        {
            var isOutOfBorder = destructionBoundaries.IsOutOfBorder(transform.position);
            return (isOutOfBorder || isSliced) && !isMagnetEffectActive;
        }
    }
}