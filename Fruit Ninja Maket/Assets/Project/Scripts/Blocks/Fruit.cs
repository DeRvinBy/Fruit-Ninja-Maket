using Project.Scripts.Extensions;
using Project.Scripts.GameSettings.BlockSettings;
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

        private float lifeTime = 0;
        private AdditionalFruitSettings fruitSettings;
        private PhysicalSettings physicalSettings;
        
        public UnityEvent<Vector2, int> OnFruitNotSliced { get; } = new UnityEvent<Vector2, int>();
        public UnityEvent<Vector2, int> OnFruitSliced { get; } = new UnityEvent<Vector2, int>();

        private void Update()
        {
            lifeTime += Time.deltaTime * physicalSettings.SlowdownCoefficient;
        }

        public void InitializeSettings(AdditionalFruitSettings fruitSettings, PhysicalSettings physicalSettings)
        {
            leftSpriteComp.sprite = fruitSettings.LeftHalfOfSprite;
            rightSpriteComp.sprite = fruitSettings.RightHalfOfSprite;
            particlesAnimator.ChangeParticlesColor(fruitSettings.SprayColor);
            this.fruitSettings = fruitSettings;
            this.physicalSettings = physicalSettings;
        }

        public override void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            
            base.Slice(slicingDirection);

            particlesAnimator.PlayParticles();

            SliceByDirection(slicingDirection);

            SendScoreBySliceFruit();
        }

        private void SendScoreBySliceFruit()
        {
            var scoreSettings = fruitSettings.ScoreSettings;
            var score = scoreSettings.GetScoreByTime(lifeTime);
            OnFruitSliced?.Invoke(transform.position, score);
        }

        private void SliceByDirection(Vector2 slicingDirection)
        {
            var leftDirection = Vector2.Perpendicular(slicingDirection);
            var rightDirection = -Vector2.Perpendicular(slicingDirection);
            PushHalfInDirection(leftSpriteComp, leftDirection);
            PushHalfInDirection(rightSpriteComp, rightDirection);
        }
        
        private void PushHalfInDirection(Component halfComponent, Vector2 direction)
        {
            var colliderObject = halfComponent.GetComponent<ObjectCollider>();
            var halfSettings = fruitSettings.HalfSettings;
            colliderObject.SetMass(halfSettings.HalfMass);
            colliderObject.SetPhysicalSettings(physicalSettings);
            colliderObject.SetMovement(direction * halfSettings.HalfVelocity);
            colliderObject.physicalMovement.enabled = true;
            colliderObject.isEnabledCollider = true;
        }
        
        protected override void OnDestroyBlock()
        {
            base.OnDestroyBlock();
            if(!isSliced)
            {
                Vector2 destroyPosition = destructionBoundaries.GetDestructionPosition(transform.position);
                OnFruitNotSliced?.Invoke(destroyPosition, fruitSettings.CountOfReducingLives);
            }
            OnFruitNotSliced?.RemoveAllListeners();
            OnFruitSliced?.RemoveAllListeners();
        }

        protected override bool IsCanDestroy()
        {
            var isLeftHalfOutOfBorder = destructionBoundaries.IsOutOfBorder(leftSpriteComp.transform.position);
            var isRightHalfOutOfBorder = destructionBoundaries.IsOutOfBorder(rightSpriteComp.transform.position);
            var isParticlesCompleted = particlesAnimator.IsParticlesComplete();
            return isLeftHalfOutOfBorder && isRightHalfOutOfBorder && isParticlesCompleted;
        }
    }
}