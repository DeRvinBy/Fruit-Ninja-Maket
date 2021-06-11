using Scripts.Animations.Abstract;
using Scripts.GameSettings.FruitSettings;
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

        private void Start()
        {
            scaleAnimation.StartAnimation();
            rotateAnimation.StartAnimation();

            destructionBoundaryY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
            destructionBoundaryY += DESTRUCTION_OFFSET;

            StartCoroutine(DestroyObject());
        }

        public void Update()
        {
            

        }

        public void InitializeFruitSettings(FruitSettings fruitSettings)
        {
            this.fruitSettings = fruitSettings;
            leftSpriteComp.sprite = fruitSettings.LeftSpriteHalf;
            rightSpriteComp.sprite = fruitSettings.RightSpriteHalf;
            var particleSettings = fruitSprayParticles.main;
            particleSettings.startColor = fruitSettings.SprayColor;
        }

        public void Slice()
        {
            if (!fruitSprayParticles.isPlaying)
            {
                fruitSprayParticles.Play();
            }
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