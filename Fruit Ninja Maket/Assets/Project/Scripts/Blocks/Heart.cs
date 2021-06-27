using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Scripts.Blocks
{
    public class Heart : SliceBlock
    {
        [SerializeField] 
        private GameObject spriteObject = null;

        private BaseHeartSettings heartSettings;

        public UnityEvent<Vector2, int> OnHeartSliced { get; } = new UnityEvent<Vector2, int>();

        public void InitializeSettings(BaseHeartSettings heartSettings)
        {
            this.heartSettings = heartSettings;
        }

        public override void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            
            base.Slice(slicingDirection);
            
            particlesAnimator.PlayParticles();
            OnHeartSliced?.Invoke(transform.position, heartSettings.CountOfAddingLives);
        }
        
        protected override void DisableBlockComponent()
        {
            base.DisableBlockComponent();
            spriteObject.SetActive(false);;
        }

        protected override void OnDestroyBlock()
        {
            base.OnDestroyBlock();
            OnHeartSliced?.RemoveAllListeners();
        }

        protected override bool IsCanDestroy()
        {
            var isOutOfBorder = destructionBoundaries.IsOutOfBorder(transform.position);
            var isParticlesCompleted = particlesAnimator.IsParticlesComplete();
            return (isOutOfBorder || isSliced) && isParticlesCompleted;
        }
    }
}