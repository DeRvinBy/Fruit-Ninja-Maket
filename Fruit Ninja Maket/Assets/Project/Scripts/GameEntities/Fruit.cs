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

        private float destructionBoundaryY;

        private void Start()
        {
            int index = Random.Range(0, fruitHalfsSprites.Length);
            leftSpriteComp.sprite = fruitHalfsSprites[index].Left;
            rightSpriteComp.sprite = fruitHalfsSprites[index].Right;

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
    }
}