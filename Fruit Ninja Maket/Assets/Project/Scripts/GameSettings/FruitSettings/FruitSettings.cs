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

        public Sprite LeftHalfOfSprite { get => leftHalfOfSprite; }
        public Sprite RightHalfOfSprite { get => rightHalfOfSprite; }
        public Color SprayColor { get => sprayColor; }
        public FruitBlot FruitBlotSprite { get => fruitBlotSprite; set => fruitBlotSprite = value; }
        public float BlotLifeTime { get => blotLifeTime; set => blotLifeTime = value; }
    }
}