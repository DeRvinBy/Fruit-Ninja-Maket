using Scripts.GameEntities;
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
        private Color sprayColor = Color.white;

        private FruitBlot fruitBlotSprite;
        private float blotLifeTime;
        private float halfsVelocityCoef;

        public Sprite LeftHalfOfSprite { get => leftHalfOfSprite; }
        public Sprite RightHalfOfSprite { get => rightHalfOfSprite; }
        public Color SprayColor { get => sprayColor; }
        public FruitBlot FruitBlotSprite { get => fruitBlotSprite; }
        public float BlotLifeTime { get => blotLifeTime; }
        public float HalfsVelocityCoef { get => halfsVelocityCoef; }

        public void SetOtherSettings(FruitBlot fruitBlotSprite, float blotLifeTime, float halfsVelocityCoef)
        {
            this.fruitBlotSprite = fruitBlotSprite;
            this.blotLifeTime = blotLifeTime;
            this.halfsVelocityCoef = halfsVelocityCoef;
        }
    }
}