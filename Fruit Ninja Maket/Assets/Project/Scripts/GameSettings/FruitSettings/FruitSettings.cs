using System;
using UnityEngine;

namespace Scripts.GameSettings.FruitSettings
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
        
        private float halfsVelocityCoef;

        public Sprite LeftHalfOfSprite { get => leftHalfOfSprite; }
        public Sprite RightHalfOfSprite { get => rightHalfOfSprite; }
        public Color SprayColor { get => fruitJuiceColor; }
        public float HalfsVelocityCoef { get => halfsVelocityCoef; }

        public void SetOtherSettings(float halfsVelocityCoef)
        {
            this.halfsVelocityCoef = halfsVelocityCoef;
        }
    }
}