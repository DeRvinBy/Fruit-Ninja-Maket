using Scripts.Animations;
using UnityEngine;

namespace Scripts.GameEntities
{
    public class FruitBlot : MonoBehaviour
    {
        [SerializeField]
        private float offsetZ = 5f;

        [SerializeField]
        private float minRotation = 0f;

        [SerializeField]
        private float maxRotation = 360f;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private FadeAnimation fadeAnimation;

        public void Initialize(Color color, float lifeTime)
        {
            float angle = Random.Range(minRotation, maxRotation);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            transform.position += Vector3.forward * offsetZ;
            spriteRenderer.color = color;
            fadeAnimation.PlayAnimation(lifeTime);
            Destroy(gameObject, lifeTime);
        }
    }
}
