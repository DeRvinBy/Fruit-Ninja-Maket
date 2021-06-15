using DG.Tweening;
using Scripts.Animations.Interfaces;
using UnityEngine;

namespace Scripts.Animations.Abstract
{
    public abstract class TransformAnimation : MonoBehaviour, IPlayAnimation, IPauseAnimation
    {
        [SerializeField]
        protected float duratinon = 1f;

        public abstract void PlayAnimation();

        public abstract void PauseAnimation();

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}
