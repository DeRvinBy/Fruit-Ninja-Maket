using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Animations.UIAnimations
{
    public class ButtonAnimation : MonoBehaviour
    {
        [SerializeField] 
        private float duration = 1f;

        [SerializeField] 
        private RectTransform rectTransform = null;
        
        [SerializeField]
        private Ease scaleEase = Ease.Linear;
        
        [SerializeField] 
        private float startScale = 1f;
        
        [SerializeField] 
        private float targetScale = 0.8f;

        [SerializeField] 
        private Image image = null;
        
        [SerializeField]
        private Color startColor = Color.black;
        
        [SerializeField]
        private Color targetColor = Color.white;

        private Sequence sequence;

        private void Start()
        {
            image.color = startColor;
            CreateAnimation();
        }

        private void CreateAnimation()
        {
            var localScale = rectTransform.localScale;
            var halfDuration = duration / 2f;
            var scaleParams = new TweenParams().SetEase(scaleEase);

            sequence = DOTween.Sequence();
            sequence.Pause();
            sequence.SetAutoKill(false);
            
            var scale = localScale * targetScale;
            sequence.Append(rectTransform.DOScale(scale, halfDuration).SetAs(scaleParams));
            sequence.Join(image.DOColor(targetColor, halfDuration));
            scale = localScale * startScale;
            sequence.Append(rectTransform.DOScale(scale, halfDuration).SetAs(scaleParams));
            sequence.Join(image.DOColor(startColor, halfDuration));
            
            sequence.OnComplete(() => sequence.Rewind());
        }

        public void PlayAnimation()
        {
            if (!sequence.IsPlaying())
            {
                sequence.Play();
            }
        }

        private void OnDestroy()
        {
            sequence.Kill(false);
        }
    }
}