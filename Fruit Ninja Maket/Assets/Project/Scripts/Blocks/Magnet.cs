using System.Collections;
using Project.Scripts.Controllers.Blocks;
using Project.Scripts.GameSettings.BlockSettings;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.Blocks
{
    public class Magnet : SliceBlock
    {
        private BaseMagnetSettings magnetSettings;
        private PhysicalController physicalController;
        private bool isMagnetEffectActive;

        protected override void OnStartBlock()
        {
            base.OnStartBlock();
            physicalController = controllersManager.GetPhysicalController();
        }

        public void InitializeSettings(BaseMagnetSettings magnetSettings)
        {
            this.magnetSettings = magnetSettings;
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
            physicalController.ActivateMagnetAtPosition(transform.position);
            yield return new WaitForSeconds(magnetSettings.MagnetEffectTime);
            physicalController.DeactivateMagnet();
            isMagnetEffectActive = false;
        }
        
        protected override bool IsCanDestroy()
        {
            var isOutOfBorder = destructionBoundaries.IsOutOfBorder(transform.position);
            return (isOutOfBorder || isSliced) && !isMagnetEffectActive;
        }
    }
}