using System;
using UnityEngine;

namespace Scripts.GameSettings.FruitSettings
{   
    [Serializable]
    public class FruitSettings
    {
        [SerializeField]
        private Sprite leftSprite = null;

        [SerializeField]
        private Sprite rightSprite = null;

        [SerializeField]
        private Color sprayColor = Color.white;

        public Sprite LeftSpriteHalf { get => leftSprite; }

        public Sprite RightSpriteHalf { get => rightSprite; }

        public Color SprayColor { get => sprayColor; }
    }
}