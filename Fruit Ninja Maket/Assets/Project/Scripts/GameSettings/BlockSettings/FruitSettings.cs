using System;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings
{   
    [Serializable]
    public class FruitSettings
    {
        [SerializeField]
        private Sprite leftHalfOfSprite = null;

        [SerializeField]
        private Sprite rightHalfOfSprite = null;

        [SerializeField]
        private Color fruitJuiceColor = Color.white;

        private float halfVelocity;

        public Sprite LeftHalfOfSprite { get => leftHalfOfSprite; }
        public Sprite RightHalfOfSprite { get => rightHalfOfSprite; }
        public Color SprayColor { get => fruitJuiceColor; }
        public float HalfVelocity { get => halfVelocity; }

        public void SetOtherSettings(float halfsVelocityCoef)
        {
            this.halfVelocity = halfsVelocityCoef;
        }
    }
}