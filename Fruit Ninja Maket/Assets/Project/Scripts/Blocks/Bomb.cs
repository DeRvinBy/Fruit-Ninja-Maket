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
            this.blockController = controller;
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
            var blocks = blockController.GetBlocksInRadius(transform.position, bombSettings.ExplosionRadius);
            foreach (var block in blocks)
            {
                var direction = block.transform.position - transform.position;
                var distance = direction.magnitude;
                var forceCoef = distance / bombSettings.ExplosionRadius;
                block.SetMovement(direction.normalized * (bombSettings.ExplosionForce * forceCoef));
            }
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