using UnityEngine;

namespace Scripts.GameEntities
{
    public class Fruit : MonoBehaviour
    {
        private const float DESTRUCTION_OFFSET = -1f;

        private float destructionBoundaryY;

        private void Start()
        {
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