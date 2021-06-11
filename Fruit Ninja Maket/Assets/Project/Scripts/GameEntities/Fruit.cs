using Scripts.Animations.Abstract;
using Scripts.GameSettings.FruitSettings;
using Scripts.Physics;
using System.Collections;
using UnityEngine;

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

        private FruitSettings fruitSettings;
        private float destructionBoundaryY;
        private bool isSliced;

        private void Start()
        {
            scaleAnimation.PlayAnimation();
            rotateAnimation.PlayAnimation();

            destructionBoundaryY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
            destructionBoundaryY += DESTRUCTION_OFFSET;

            StartCoroutine(DestroyObject());
        }

        public void InitializeFruitSettings(FruitSettings settings)
        {
            leftSpriteComp.sprite = settings.LeftHalfOfSprite;
            rightSpriteComp.sprite = settings.RightHalfOfSprite;
            var particleSettings = fruitSprayParticles.main;
            particleSettings.startColor = settings.SprayColor;

            fruitSettings = settings;
        }

        public void Slice(Vector2 slicingDirection)
        {
            if (!isSliced)
            {
                isSliced = true;
                fruitSprayParticles.Play();

                PushHalfs(slicingDirection);

                SpawnFruitBlot();
            }
        }

        private void PushHalfs(Vector2 slicingDirection)
        {
            GetComponent<PhysicalMovement>().enabled = false;
            GetComponent<ObjectCollider>().enabled = false;

            scaleAnimation.PauseAnimation();
            rotateAnimation.PauseAnimation();

            PhysicalMovement movementLeft = leftSpriteComp.GetComponent<PhysicalMovement>();
            movementLeft.AddVelocity((Vector2)transform.up + Vector2.right * 5f);
            movementLeft.enabled = true;

            PhysicalMovement movementRight = rightSpriteComp.GetComponent<PhysicalMovement>();
            movementRight.AddVelocity((Vector2)transform.up + Vector2.left * 5f);
            movementRight.enabled = true;
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