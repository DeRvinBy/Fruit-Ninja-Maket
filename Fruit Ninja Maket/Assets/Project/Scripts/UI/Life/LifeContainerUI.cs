using Project.Scripts.Animations.UIAnimations;
using UnityEngine;

namespace Project.Scripts.UI.Life
{
    public class LifeContainerUI : MonoBehaviour
    {
        [SerializeField]
        private LifeImageAnimation lifeImage = null;

        private bool isEmpty;

        public void SetActiveContainer()
        {
            lifeImage.PlayReverseFadeAnimation();
            isEmpty = false;
        }
        
        public void ActivateLifeImage(Vector2 animationPosition)
        {
            if (!isEmpty) return;
            
            lifeImage.PlayMoveAnimation(animationPosition);
            isEmpty = false;
        }
        
        public void DeactivateLifeImage()
        {
            if (isEmpty) return;
            
            lifeImage.PlayFadeAnimation();
            isEmpty = true;
        }
    }
}
