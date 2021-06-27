using System;
using Project.Scripts.Animations.Abstract;
using Project.Scripts.Animations.UIAnimations;
using TMPro;
using UnityEngine;

namespace Project.Scripts.UI.Score
{
    public class SceneScoreUI : MonoBehaviour
    {
        private const string ScoreFormat = "{0}";
        private const string ComboFormat = "x{0}";
        
        [SerializeField]
        private float destroyDelay = 2f;

        [SerializeField]
        private TMP_Text scoreText = null;
        
        [SerializeField]
        private TMP_Text comboText = null;

        [SerializeField]
        private RectTransformMoveOffsetAnimation moveAnimation = null;

        [SerializeField]
        private FadeCanvasGroupAnimation canvasGroupAnimation = null;

        public void InitializeScore(int score, int combo)
        {
            scoreText.text = string.Format(ScoreFormat, score);
            comboText.text = string.Format(ComboFormat, combo);
            moveAnimation.PlayAnimation();
            canvasGroupAnimation.PlayAnimation();
            Destroy(gameObject, destroyDelay);
        }
    }
}