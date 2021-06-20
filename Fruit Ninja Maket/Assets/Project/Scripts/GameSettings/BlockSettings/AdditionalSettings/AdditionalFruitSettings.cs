using System;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.AdditionalSettings
{   
    [Serializable]
    public class AdditionalFruitSettings
    {
        [SerializeField]
        private Sprite leftHalfOfSprite = null;

        [SerializeField]
        private Sprite rightHalfOfSprite = null;

        [SerializeField]
        private Color fruitJuiceColor = Color.white;

        private int countOfReducingLives;
        private float halfVelocity;
        private float halfGravity;

        public Sprite LeftHalfOfSprite { get => leftHalfOfSprite; }
        public Sprite RightHalfOfSprite { get => rightHalfOfSprite; }
        public Color SprayColor { get => fruitJuiceColor; }
        public float HalfVelocity { get => halfVelocity; }
        public float HalfGravity { get => halfGravity; }
        public int CountOfReducingLives => countOfReducingLives;

        public void SetOtherSettings(float halfGravity, float halfVelocity, int countOfReducingLives)
        {
            this.halfGravity = halfGravity;
            this.halfVelocity = halfVelocity;
            this.countOfReducingLives = countOfReducingLives;
        }
    }
}