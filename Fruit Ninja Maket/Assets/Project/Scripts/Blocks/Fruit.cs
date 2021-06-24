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

        private float lifeTime = 0;
        private AdditionalFruitSettings fruitSettings;
        
        public UnityEvent<Vector2, int> OnFruitNotSliced { get; } = new UnityEvent<Vector2, int>();
        public UnityEvent<Vector2, int> OnFruitSliced { get; } = new UnityEvent<Vector2, int>();

        private void Update()
        {
            lifeTime += Time.deltaTime;
        }

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
            colliderObject.SetMassOfBlock(halfSettings.HalfMass);
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
            var isParticlesCompleted = !blotsParticles.isPlaying && !sprayParticles.isPlaying;
            return isLeftHalfOutOfBorder && isRightHalfOutOfBorder && isParticlesCompleted;
        }
    }
}