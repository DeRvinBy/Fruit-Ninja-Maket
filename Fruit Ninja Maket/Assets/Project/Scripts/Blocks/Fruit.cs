using Project.Scripts.GameSettings.BlockSettings.AdditionalSettings;
using Project.Scripts.Physics;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Scripts.Blocks
{
    public class Fruit : SliceBlock
    {
        [Header("Fruits components")]
        
        [SerializeField]
        private SpriteRenderer leftSpriteComp = null;

        [SerializeField]
        private SpriteRenderer rightSpriteComp = null;

        [SerializeField]
        private ParticleSystem sprayParticles = null;
        
        [SerializeField]
        private ParticleSystem blotsParticles = null;

        private AdditionalFruitSettings fruitSettings;
        
        public UnityEvent<Vector2, int> OnFruitNotSliced { get; } = new UnityEvent<Vector2, int>();
        public UnityEvent<Vector2> OnFruitSliced { get; } = new UnityEvent<Vector2>();

        public void InitializeSettings(AdditionalFruitSettings settings)
        {
            leftSpriteComp.sprite = settings.LeftHalfOfSprite;
            rightSpriteComp.sprite = settings.RightHalfOfSprite;
            SetParticlesColor(sprayParticles, settings.SprayColor);
            SetParticlesColor(blotsParticles, settings.SprayColor);
            fruitSettings = settings;
        }

        private void SetParticlesColor(ParticleSystem particles, Color color)
        {
            var particleSettings = particles.main;
            particleSettings.startColor = color;
        }

        public override void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            
            base.Slice(slicingDirection);

            sprayParticles.Play();
            blotsParticles.Play();
            
            PushHalfInDirection(leftSpriteComp, slicingDirection + Vector2.right);
            PushHalfInDirection(rightSpriteComp, slicingDirection + Vector2.left);

            OnFruitSliced?.Invoke(transform.position);
        }

        private void PushHalfInDirection(Component halfComponent, Vector2 direction)
        {
            var movement = halfComponent.GetComponent<ObjectCollider>();
            movement.SetGravityVelocity(fruitSettings.HalfGravity);
            movement.SetMovement(direction * fruitSettings.HalfVelocity);
            movement.physicalMovement.enabled = true;
            movement.isEnabledCollider = true;
        }
        
        protected override void OnDestroyBlock()
        {
            base.OnDestroyBlock();
            if(!isSliced)
            {
                Vector2 destroyPosition = transform.position;
                destroyPosition.y += DESTRUCTION_OFFSET_UP;
                OnFruitNotSliced?.Invoke(destroyPosition, fruitSettings.CountOfReducingLives);
            }
            OnFruitNotSliced?.RemoveAllListeners();
            OnFruitSliced?.RemoveAllListeners();
        }

        protected override bool IsCanDestroy()
        {
            var isLeftHalfOutOfBorder = leftSpriteComp.transform.position.y < destructionBoundaryY;
            var isRightHalfOutOfBorder = rightSpriteComp.transform.position.y < destructionBoundaryY;
            var isParticlesCompleted = !blotsParticles.isPlaying || !sprayParticles.isPlaying;
            return isLeftHalfOutOfBorder && isRightHalfOutOfBorder && isParticlesCompleted;
        }
    }
}