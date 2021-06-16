using System.Collections;
using Scripts.Animations.Abstract;
using Scripts.GameSettings.FruitSettings;
using Scripts.Physics;
using UnityEngine;
using UnityEngine.Events;

namespace Project.Scripts.GameEntities
{
    public partial class Fruit : MonoBehaviour
    {
        private const float DESTRUCTION_OFFSET_UP = 2f;
        private const float DESTRUCTION_OFFSET_DOWN = -1f;

        [SerializeField]
        private SpriteRenderer leftSpriteComp = null;

        [SerializeField]
        private SpriteRenderer rightSpriteComp = null;

        [SerializeField]
        private TransformAnimation scaleAnimation = null;

        [SerializeField]
        private TransformAnimation rotateAnimation = null;

        [SerializeField]
        private ParticleSystem sprayParticles = null;
        
        [SerializeField]
        private ParticleSystem blotsParticles = null;

        private UnityEvent onFruitDestroyed = new UnityEvent();
        private UnityEvent<Vector2> onFruitNotSliced = new UnityEvent<Vector2>();
        private UnityEvent<Vector2> onFruitSliced = new UnityEvent<Vector2>();
        
        private float destructionBoundaryY;
        private float halfsVelocity;
        private bool isSliced;

        public UnityEvent OnFruitDestroyed { get => onFruitDestroyed; }
        public UnityEvent<Vector2> OnFruitNotSliced { get => onFruitNotSliced; }
        public UnityEvent<Vector2> OnFruitSliced { get => onFruitSliced; }

        private void Start()
        {
            scaleAnimation.PlayAnimation();
            rotateAnimation.PlayAnimation();

            destructionBoundaryY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
            destructionBoundaryY += DESTRUCTION_OFFSET_DOWN;

            StartCoroutine(DestroyObject());
        }

        private void OnDestroy()
        {
            onFruitDestroyed?.RemoveAllListeners();
            onFruitNotSliced?.RemoveAllListeners();
            onFruitSliced?.RemoveAllListeners();
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
            if (!isSliced)
            {
                isSliced = true;
                sprayParticles.Play();
                blotsParticles.Play();

                DisableOptionsOfMainObject();
                PushHalfInDirection(leftSpriteComp, slicingDirection + Vector2.right);
                PushHalfInDirection(rightSpriteComp, slicingDirection + Vector2.left);

                onFruitSliced.Invoke(transform.position);
            }
        }

        private void DisableOptionsOfMainObject()
        {
            GetComponent<PhysicalMovement>().enabled = false;
            GetComponent<ObjectCollider>().enabled = false;

            scaleAnimation.PauseAnimation();
            rotateAnimation.PauseAnimation();
        }

        private void PushHalfInDirection(SpriteRenderer halfComponent, Vector2 direction)
        {
            PhysicalMovement moevement = halfComponent.GetComponent<PhysicalMovement>();
            moevement.AddVelocity(direction * halfsVelocity);
            moevement.enabled = true;
        }

        private IEnumerator DestroyObject()
        {
            yield return new WaitUntil(() => IsCanDestroy());
            if(!isSliced)
            {
                Vector2 destroyPosition = transform.position;
                destroyPosition.y += DESTRUCTION_OFFSET_UP;
                onFruitNotSliced?.Invoke(destroyPosition);
            }
            onFruitDestroyed?.Invoke();
            Destroy(gameObject);
        }

        private bool IsCanDestroy()
        {
            bool isLeftHalfsOutOfBorder = leftSpriteComp.transform.position.y < destructionBoundaryY;
            bool isRightHalfsOutOfBorder = rightSpriteComp.transform.position.y < destructionBoundaryY;
            bool isParticlesPlaying = blotsParticles.isPlaying || sprayParticles.isPlaying;
            return isLeftHalfsOutOfBorder && isRightHalfsOutOfBorder && !isParticlesPlaying;
        }
    }
}