using DG.Tweening;
using Scripts.Animations.Interfaces;
using UnityEngine;

namespace Scripts.Animations.Abstract
{
    public abstract class TransformAnimation : MonoBehaviour, IAnimation
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
