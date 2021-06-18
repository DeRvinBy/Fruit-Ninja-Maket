using System;
using DG.Tweening;
using UnityEngine;

namespace Project.Scripts.UI.Game
{
    public class SceneTransition : MonoBehaviour
    {
        [SerializeField] 
        private float duration = 1f;
        
        [SerializeField]
        private float showAlpha = 0f;
        
        [SerializeField]
        private float hideAlpha = 1f;

        [SerializeField] 
        private CanvasGroup uiElement = null;

        public void HideTransition(Action callback)
        {
            uiElement.alpha = hideAlpha;
            uiElement.DOFade(showAlpha, duration).OnComplete(() =>
            {
                uiElement.blocksRaycasts = false;
                callback?.Invoke();
            });
        }

        public void ShowTransition(Action callback)
        {
            uiElement.alpha = showAlpha;
            uiElement.blocksRaycasts = true;
            uiElement.DOFade(hideAlpha, duration).OnComplete(() => callback?.Invoke());
        }
    }
}
