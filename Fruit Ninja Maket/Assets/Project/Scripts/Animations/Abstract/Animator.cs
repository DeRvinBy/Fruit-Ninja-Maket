using UnityEngine;

namespace Project.Scripts.Animations.Abstract
{
    public abstract class Animator : MonoBehaviour
    {
        [SerializeField] 
        protected float duration = 1f;

        public abstract void PlayAnimation();
        public abstract void PauseAnimation();
        public abstract void PlayReverseAnimation();
        public abstract void CancelAnimation();

        private void OnDestroy()
        {
            CancelAnimation();
        }
    }
}