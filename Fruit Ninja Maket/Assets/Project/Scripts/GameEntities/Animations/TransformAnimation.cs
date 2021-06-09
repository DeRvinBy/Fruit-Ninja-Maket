using DG.Tweening;
using UnityEngine;

namespace Scripts.GameEntities.Animations
{
    public abstract class TransformAnimation : MonoBehaviour
    {
        [SerializeField]
        protected float duratinon = 1f;

        public abstract void StartAnimation();

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}
