using System;
using Project.Scripts.Controllers;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Scripts.Blocks
{
    public class Bomb : SliceBlock
    {
        [SerializeField] 
        private ParticleSystem explosionParticles = null;

        [SerializeField] 
        private GameObject spriteObject = null;
        
        private BaseBombSettings bombSettings;
        private BlockController blockController;
        
        public UnityEvent<int> OnBombSliced { get; } = new UnityEvent<int>();

        public void InitializeSettings(BaseBombSettings bombSettings, BlockController controller)
        {
            var explosionShape = explosionParticles.shape;
            explosionShape.radius = bombSettings.ExplosionRadius;
            this.bombSettings = bombSettings;
            this.blockController = blockController;
        }
        
        public override void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            
            base.Slice(slicingDirection);
            
            spriteObject.SetActive(false);
            explosionParticles.Play();
            PushBlocksFromBomb();
            OnBombSliced?.Invoke(bombSettings.CountOfReducingLives);
        }

        private void PushBlocksFromBomb()
        {
            
        }

        protected override void OnDestroyBlock()
        {
            base.OnDestroyBlock();
            OnBombSliced?.RemoveAllListeners();
        }

        protected override bool IsCanDestroy()
        {
            var isOutOfBorder = transform.position.y < destructionBoundaryY || isSliced;
            var isParticlesCompleted = !explosionParticles.isPlaying;
            return isOutOfBorder && isParticlesCompleted;
        }
    }
}