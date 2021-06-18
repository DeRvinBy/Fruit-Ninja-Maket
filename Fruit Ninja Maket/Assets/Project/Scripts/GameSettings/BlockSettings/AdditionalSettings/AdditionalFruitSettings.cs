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

        public Sprite LeftHalfOfSprite { get => leftHalfOfSprite; }
        public Sprite RightHalfOfSprite { get => rightHalfOfSprite; }
        public Color SprayColor { get => fruitJuiceColor; }
        public float HalfVelocity { get => halfVelocity; }
        public int CountOfReducingLives => countOfReducingLives;

        public void SetOtherSettings(float halfVelocity, int countOfReducingLives)
        {
            this.halfVelocity = halfVelocity;
            this.countOfReducingLives = countOfReducingLives;
        }
    }
}