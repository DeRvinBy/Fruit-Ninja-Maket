using DG.Tweening;
using Scripts.Animations.Interfaces;
using UnityEngine;

namespace Scripts.Animations.Abstract
{
    public abstract class SpriteRendererAnimation : MonoBehaviour, IAnimationWithDuration
    {
        [SerializeField]
        protected SpriteRenderer spriteRenderer;

        public abstract void PlayAnimation(float time);

        private void OnDestroy()
        {
            spriteRenderer.DOKill();
        }
    }
}
