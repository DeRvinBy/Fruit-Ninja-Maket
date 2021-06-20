using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Animations.UIAnimations
{
    public class LifeImageAnimation : MonoBehaviour
    {
        [SerializeField] 
        private float duration = 1f;

        [SerializeField] 
        private RectTransform rectTransform = null;
        
        [SerializeField]
        private Ease ease = Ease.Linear;

        [SerializeField] 
        private Image image = null;

        [SerializeField] 
        private float targetAlpha = 0f;
        
        private Vector2 startPosition;
        private Color startColor;
        private Color targetColor;

        private Tween moveTween;
        private Tween fadeTween;
        private Tween reverseFadeTween;

        private void Start()
        {
            startPosition = rectTransform.anchoredPosition;
            startColor = image.color;
            targetColor = new Color(startColor.r, startColor.g, startColor.g, targetAlpha);

            var tweenParams = new TweenParams().SetAutoKill(false);
            
            moveTween = rectTransform.DOLocalMove(startPosition, duration).SetAs(tweenParams).SetEase(ease).Pause();
            fadeTween = image.DOColor(targetColor, duration).SetAs(tweenParams).Pause();
            reverseFadeTween = image.DOColor(startColor, duration).SetAs(tweenParams).Pause();
        }

        public void PlayReverseFadeAnimation()
        {
            image.color = startColor;
            reverseFadeTween.Rewind();
            reverseFadeTween.Play();
        }

        public void PlayMoveAnimation(Vector2 startAnimationPosition)
        {
            fadeTween.Pause();
            image.color = startColor;
            rectTransform.position = startAnimationPosition;
            moveTween.Rewind();
            moveTween.Play();
        }
        
        public void PlayFadeAnimation()
        {
            fadeTween.Rewind();
            fadeTween.Play();
        }

        private void OnDestroy()
        {
            moveTween.Kill();
            fadeTween.Kill();
        }
    }
}