using System;
using Project.Scripts.Animations.Abstract;
using TMPro;
using UnityEngine;

namespace Project.Scripts.UI.Score
{
    public class SceneScoreUI : MonoBehaviour
    {
        private const string TextFormat= "+{0}";

        [SerializeField]
        private float destroyDelay = 2f;

        [SerializeField]
        private TMP_Text scoreText = null;

        [SerializeField]
        private UIRectTransformAnimation moveAnimation = null;

        [SerializeField]
        private UICanvasGroupAnimation canvasGroupAnimation = null;

        public void InitializeScore(int score)
        {
            scoreText.text = String.Format(TextFormat, score.ToString());
            moveAnimation.PlayAnimation();
            canvasGroupAnimation.PlayAnimation();
            Destroy(gameObject, destroyDelay);
        }
    }
}