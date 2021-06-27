using Project.Scripts.Controllers.Blocks;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Scripts.Blocks
{
    public class Bomb : SliceBlock
    {
        [SerializeField] 
        private GameObject spriteObject = null;
        
        private BaseBombSettings bombSettings;
        private BlockController blockController;
        
        public UnityEvent<int> OnBombSliced { get; } = new UnityEvent<int>();

        protected override void OnStartBlock()
        {
            base.OnStartBlock();
            blockController = controllersManager.GetBlockController();
        }

        public void InitializeSettings(BaseBombSettings bombSettings)
        {
            this.bombSettings = bombSettings;
        }
        
        public override void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            
            base.Slice(slicingDirection);
            
            particlesAnimator.PlayParticles();
            blockController.PushBlocksFromBomb(transform.position, bombSettings);
            OnBombSliced?.Invoke(bombSettings.CountOfReducingLives);
        }

        protected override void DisableBlockComponent()
        {
            base.DisableBlockComponent();
            spriteObject.SetActive(false);;
        }

        protected override void OnDestroyBlock()
        {
            base.OnDestroyBlock();
            OnBombSliced?.RemoveAllListeners();
        }

        protected override bool IsCanDestroy()
        {
            var isOutOfBorder = destructionBoundaries.IsOutOfBorder(transform.position);
            var isParticlesCompleted = particlesAnimator.IsParticlesComplete();
            return (isOutOfBorder || isSliced) && isParticlesCompleted;
        }
    }
}