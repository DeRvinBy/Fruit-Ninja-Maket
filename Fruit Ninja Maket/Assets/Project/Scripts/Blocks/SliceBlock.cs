using System.Collections;
using Project.Scripts.Animations.Abstract;
using Project.Scripts.Physics;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Scripts.Blocks
{
    public abstract class SliceBlock : ObjectCollider
    {
        protected const float DESTRUCTION_OFFSET_UP = 2f;
        protected const float DESTRUCTION_OFFSET_DOWN = -1f;

        [Header("Physics Components")]

        [SerializeField]
        private PhysicalMovement physicalMovement = null;
        
        [Header("Animations")]
        [SerializeField]
        private RandomTransformAnimation scaleAnimation = null;

        [SerializeField]
        private RandomTransformAnimation rotateAnimation = null;
        
        public UnityEvent<SliceBlock> OnBlockDestroyed { get; } = new UnityEvent<SliceBlock>();
        
        protected float destructionBoundaryY;
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
            scaleAnimation?.PlayAnimation();
            rotateAnimation?.PlayAnimation();
            
            destructionBoundaryY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
            destructionBoundaryY += DESTRUCTION_OFFSET_DOWN;

            StartCoroutine(DestroyBlock());
        }
        
        protected virtual void OnDestroyBlock()
        {
            OnBlockDestroyed?.RemoveAllListeners();
        }

        public void SetMovement(Vector2 velocity)
        {
            physicalMovement.AddVelocity(velocity);
        }
        
        public virtual void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            isSliced = true;
            DisableBlockComponent();
        }

        protected virtual void DisableBlockComponent()
        {
            physicalMovement.enabled = false;

            scaleAnimation.PauseAnimation();
            rotateAnimation.PauseAnimation();
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