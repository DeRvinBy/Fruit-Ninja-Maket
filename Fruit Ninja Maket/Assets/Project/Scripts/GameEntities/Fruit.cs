using Scripts.GameEntities.Animations;
using Scripts.GameEntities.Containers;
using UnityEngine;

namespace Scripts.GameEntities
{
    public partial class Fruit : MonoBehaviour
    {
        private const float DESTRUCTION_OFFSET = -1f;

        [SerializeField]
        private FruitHalfsSprites[] fruitHalfsSprites = null;

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

        private float destructionBoundaryY;

        private void Start()
        {
            int index = Random.Range(0, fruitHalfsSprites.Length);
            leftSpriteComp.sprite = fruitHalfsSprites[index].Left;
            rightSpriteComp.sprite = fruitHalfsSprites[index].Right;

            scaleAnimation.StartAnimation();
            rotateAnimation.StartAnimation();

            destructionBoundaryY = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
            destructionBoundaryY += DESTRUCTION_OFFSET;
        }

        public void Update()
        {
            if(transform.position.y < destructionBoundaryY)
            {
                Destroy(gameObject);
            }
        }

        public void Slice()
        {
            if (!fruitSprayParticles.isPlaying)
            {
                fruitSprayParticles.Play();
            }
        }
    }
}