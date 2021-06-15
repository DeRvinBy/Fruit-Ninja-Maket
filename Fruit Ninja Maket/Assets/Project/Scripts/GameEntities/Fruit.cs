using Scripts.Animations.Abstract;
using Scripts.GameSettings.FruitSettings;
using Scripts.Physics;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.GameEntities
{
    public partial class Fruit : MonoBehaviour
    {
        private const float DESTRUCTION_OFFSET = -1f;

        [SerializeField]
        private SpriteRenderer leftSpriteComp = null;

        [SerializeField]
        private SpriteRenderer rightSpriteComp = null;

        [SerializeField]
        private TransformAnimation scaleAnimation = null;

        [SerializeField]
        private TransformAnimation rotateAnimation = null;

        [SerializeField]
        private ParticleSystem fruitSprayParticles = null;

        private UnityEvent onFruitDestroyed = new UnityEvent();
        private UnityEvent<Vector2> onFruitSliced = new UnityEvent<Vector2>();

        private FruitSettings fruitSettings;
        private float destructionBoundaryY;
        private float halfsVelocity;
        private bool isSliced;

        public UnityEvent OnFruitDestroyed { get => onFruitDestroyed; }
        public UnityEvent<Vector2> OnFruitSliced { get => onFruitSliced; }

        private void Start()
        {
            scaleAnimation.PlayAnimation();
            rotateAnimation.PlayAnimation();

            destructionBoundaryY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
            destructionBoundaryY += DESTRUCTION_OFFSET;

            StartCoroutine(DestroyObject());
        }

        private void OnDestroy()
        {
            onFruitSliced?.RemoveAllListeners();
            onFruitDestroyed?.RemoveAllListeners();
        }

        public void InitializeFruitSettings(FruitSettings settings, float velocity)
        {
            leftSpriteComp.sprite = settings.LeftHalfOfSprite;
            rightSpriteComp.sprite = settings.RightHalfOfSprite;
            var particleSettings = fruitSprayParticles.main;
            particleSettings.startColor = settings.SprayColor;
            halfsVelocity = velocity * settings.HalfsVelocityCoef;

            fruitSettings = settings;
        }

        public void Slice(Vector2 slicingDirection)
        {
            if (!isSliced)
            {
                isSliced = true;
                fruitSprayParticles.Play();

                DisableOptionsOfMainObject();
                PushHalfInDirection(leftSpriteComp, slicingDirection + Vector2.right);
                PushHalfInDirection(rightSpriteComp, slicingDirection + Vector2.left);
                SpawnFruitBlot();

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

        private void SpawnFruitBlot()
        {
            FruitBlot blotSprite = Instantiate(fruitSettings.FruitBlotSprite, transform.position, Quaternion.identity);
            blotSprite.Initialize(fruitSettings.SprayColor, fruitSettings.BlotLifeTime);
            blotSprite.transform.localScale = scaleAnimation.transform.localScale;
        }

        private IEnumerator DestroyObject()
        {
            yield return new WaitUntil(() => IsCanDestroy());
            if(!isSliced)
            {
                onFruitDestroyed?.Invoke();
            }
            Destroy(gameObject);
        }

        private bool IsCanDestroy()
        {
            bool isLeftHalfsOutOfBorder = leftSpriteComp.transform.position.y < destructionBoundaryY;
            bool isRightHalfsOutOfBorder = rightSpriteComp.transform.position.y < destructionBoundaryY;
            return isLeftHalfsOutOfBorder && isRightHalfsOutOfBorder && !fruitSprayParticles.isPlaying;
        }
    }
}