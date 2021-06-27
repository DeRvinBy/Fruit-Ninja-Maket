using System.Collections;
using Project.Scripts.Animations.GameAnimations;
using Project.Scripts.Blocks.BlockParticles;
using Project.Scripts.Blocks.Utils;
using Project.Scripts.Physics;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Scripts.Blocks
{
    public abstract class SliceBlock : ObjectCollider
    {
        [Header("Animations")]
        [SerializeField]
        private BlockAnimator blockAnimator = null;

        [SerializeField] 
        protected ParticlesAnimator particlesAnimator = null;

        public UnityEvent<SliceBlock> OnBlockDestroyed { get; } = new UnityEvent<SliceBlock>();
        
        protected DestructionBoundaries destructionBoundaries;
        protected bool isSliced;
        
        private void Start()
        {
            OnStartBlock();
        }
        
        private void OnDestroy()
        {
            OnDestroyBlock();
        }

        protected virtual void OnStartBlock()
        {
            blockAnimator?.PlayAnimation();

            destructionBoundaries = new DestructionBoundaries(Camera.main);

            StartCoroutine(DestroyBlock());
        }
        
        protected virtual void OnDestroyBlock()
        {
            OnBlockDestroyed?.RemoveAllListeners();
        }

        public virtual void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            isSliced = true;
            DisableBlockComponent();
        }

        protected virtual void DisableBlockComponent()
        {
            isEnabledCollider = false;
            physicalMovement.enabled = false;

            blockAnimator.PauseAnimation();
        }

        private IEnumerator DestroyBlock()
        {
            yield return new WaitUntil(IsCanDestroy);
            OnBlockDestroyed?.Invoke(this);
            Destroy(gameObject);
        }

        protected abstract bool IsCanDestroy();
    }
}