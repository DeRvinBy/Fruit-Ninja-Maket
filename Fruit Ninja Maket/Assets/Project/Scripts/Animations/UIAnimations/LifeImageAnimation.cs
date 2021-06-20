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
        private Color activeColor = Color.white;
        
        [SerializeField] 
        private Color disableColor = Color.white;

        private Vector2 startPosition;
        
        private Tween moveTween;
        private Tween fadeTween;
        private Tween reverseFadeTween;

        private void Start()
        {
            startPosition = rectTransform.anchoredPosition;

            var tweenParams = new TweenParams().SetAutoKill(false);
            
            moveTween = rectTransform.DOLocalMove(startPosition, duration).SetAs(tweenParams).SetEase(ease).Pause();
            fadeTween = image.DOColor(disableColor, duration).SetAs(tweenParams).Pause();
            reverseFadeTween = image.DOColor(activeColor, duration).SetAs(tweenParams).Pause();
        }

        public void PlayReverseFadeAnimation()
        {
            image.color = activeColor;
            reverseFadeTween.Rewind();
            reverseFadeTween.Play();
        }

        public void PlayMoveAnimation(Vector2 startAnimationPosition)
        {
            fadeTween.Pause();
            image.color = activeColor;
            rectTransform.position = startAnimationPosition;
            moveTween.Rewind();
            moveTween.Play();
        }
        
        public void PlayFadeAnimation()
        {
            image.color = activeColor;
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