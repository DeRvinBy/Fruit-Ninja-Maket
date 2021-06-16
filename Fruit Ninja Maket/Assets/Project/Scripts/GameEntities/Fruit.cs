using System.Collections;
using Project.Scripts.Animations.Abstract;
using Project.Scripts.GameSettings.FruitSettings;
using Scripts.Physics;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Scripts.GameEntities
{
    public class Fruit : MonoBehaviour
    {
        private const float DestructionOffsetUp = 2f;
        private const float DestructionOffsetDown = -1f;

        [SerializeField]
        private SpriteRenderer leftSpriteComp = null;

        [SerializeField]
        private SpriteRenderer rightSpriteComp = null;

        [SerializeField]
        private RandomTransformAnimation scaleAnimation = null;

        [SerializeField]
        private RandomTransformAnimation rotateAnimation = null;

        [SerializeField]
        private ParticleSystem sprayParticles = null;
        
        [SerializeField]
        private ParticleSystem blotsParticles = null;

        private float destructionBoundaryY;
        private float halfsVelocity;
        private bool isSliced;

        public UnityEvent OnFruitDestroyed { get; } = new UnityEvent();
        public UnityEvent<Vector2> OnFruitNotSliced { get; } = new UnityEvent<Vector2>();
        public UnityEvent<Vector2> OnFruitSliced { get; } = new UnityEvent<Vector2>();

        private void Start()
        {
            scaleAnimation.PlayAnimation();
            rotateAnimation.PlayAnimation();
            
            destructionBoundaryY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
            destructionBoundaryY += DestructionOffsetDown;

            StartCoroutine(DestroyObject());
        }

        private void OnDestroy()
        {
            OnFruitDestroyed?.RemoveAllListeners();
            OnFruitNotSliced?.RemoveAllListeners();
            OnFruitSliced?.RemoveAllListeners();
        }

        public void InitializeFruitSettings(FruitSettings settings, float velocity)
        {
            leftSpriteComp.sprite = settings.LeftHalfOfSprite;
            rightSpriteComp.sprite = settings.RightHalfOfSprite;
            SetParticlesColor(sprayParticles, settings.SprayColor);
            SetParticlesColor(blotsParticles, settings.SprayColor);
            halfsVelocity = velocity * settings.HalfsVelocityCoef;
        }

        private void SetParticlesColor(ParticleSystem particles, Color color)
        {
            var particleSettings = particles.main;
            particleSettings.startColor = color;
        }

        public void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            
            isSliced = true;
            sprayParticles.Play();
            blotsParticles.Play();

            DisableOptionsOfMainObject();
            PushHalfInDirection(leftSpriteComp, slicingDirection + Vector2.right);
            PushHalfInDirection(rightSpriteComp, slicingDirection + Vector2.left);

            OnFruitSliced.Invoke(transform.position);
        }

        private void DisableOptionsOfMainObject()
        {
            GetComponent<PhysicalMovement>().enabled = false;
            GetComponent<ObjectCollider>().enabled = false;

            scaleAnimation.PauseAnimation();
            rotateAnimation.PauseAnimation();
        }

        private void PushHalfInDirection(Component halfComponent, Vector2 direction)
        {
            var moevement = halfComponent.GetComponent<PhysicalMovement>();
            moevement.AddVelocity(direction * halfsVelocity);
            moevement.enabled = true;
        }

        private IEnumerator DestroyObject()
        {
            yield return new WaitUntil(IsCanDestroy);
            if(!isSliced)
            {
                Vector2 destroyPosition = transform.position;
                destroyPosition.y += DestructionOffsetUp;
                OnFruitNotSliced?.Invoke(destroyPosition);
            }
            OnFruitDestroyed?.Invoke();
            Destroy(gameObject);
        }

        private bool IsCanDestroy()
        {
            var isLeftHalfsOutOfBorder = leftSpriteComp.transform.position.y < destructionBoundaryY;
            var isRightHalfsOutOfBorder = rightSpriteComp.transform.position.y < destructionBoundaryY;
            var isParticlesCompleted = !blotsParticles.isPlaying || !sprayParticles.isPlaying;
            return isLeftHalfsOutOfBorder && isRightHalfsOutOfBorder && isParticlesCompleted;
        }
    }
}