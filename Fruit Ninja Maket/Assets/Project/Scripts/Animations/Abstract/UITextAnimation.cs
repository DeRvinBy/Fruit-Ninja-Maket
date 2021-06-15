using DG.Tweening;
using Scripts.Animations.Interfaces;
using TMPro;
using UnityEngine;

namespace Scripts.Animations.Abstract
{
    public abstract class UITextAnimation : MonoBehaviour, IPlayAnimation
    {
        [SerializeField]
        protected float duration = 1f;

        [SerializeField]
        protected TMP_Text text = null;

        public abstract void PlayAnimation();

        private void OnDestroy()
        {
            text.DOKill();
        }
    }
}
