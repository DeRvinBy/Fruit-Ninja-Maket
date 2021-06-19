using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Scripts.Blocks
{
    public class Heart : SliceBlock
    {
        [SerializeField] 
        private ParticleSystem heartsParticles;

        [SerializeField] 
        private GameObject spriteObject = null;

        private BaseHeartSettings heartSettings;

        public UnityEvent<int> OnHeartSliced { get; } = new UnityEvent<int>();

        public void InitializeSettings(BaseHeartSettings heartSettings)
        {
            this.heartSettings = heartSettings;
        }

        public override void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            
            base.Slice(slicingDirection);
            
            heartsParticles.Play();
            OnHeartSliced?.Invoke(heartSettings.CountOfAddingLives);
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
            var isOutOfBorder = transform.position.y < destructionBoundaryY || isSliced;
            var isParticlesCompleted = !heartsParticles.isPlaying;
            return isOutOfBorder && isParticlesCompleted;
        }
    }
}