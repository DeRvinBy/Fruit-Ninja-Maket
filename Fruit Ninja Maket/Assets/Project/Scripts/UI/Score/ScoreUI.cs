using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Project.Scripts.UI.Score
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] 
        private float animationDuration = 1f;
        
        [SerializeField] 
        private Ease animationEase = Ease.Linear;
        
        [SerializeField]
        private TMP_Text bestScoreText = null;

        [SerializeField]
        private TMP_Text currentScoreText = null;

        private int bestScore;
        private int currentScore;

        public void SetBestScore(int value)
        {
            bestScore = value;
            SetText(bestScoreText, value.ToString());
        }

        public void SetCurrentScore(int value)
        {
            currentScore = value;
            SetText(currentScoreText, value.ToString());
        }
        
        public void SetBestScoreAnimate(int value)
        {
            PlayAnimation(bestScoreText, bestScore, value);
            bestScore = value;
        }

        public void SetCurrentScoreAnimate(int value)
        {
            PlayAnimation(currentScoreText, currentScore, value);
            currentScore = value;
        }

        private void PlayAnimation(TMP_Text tmpText, int from, int to)
        {
            var tween = DOVirtual.Float((float) from, (float) to, animationDuration, score =>
            {
                var text = $"{score:f0}";
                SetText(tmpText, text);
            });
            tween.SetEase(animationEase);
            tween.OnComplete(() => tween.Kill());
        }
        
        private void SetText(TMP_Text tmpText, string value)
        {
            tmpText.text = value.ToString();
        }
    }
}
