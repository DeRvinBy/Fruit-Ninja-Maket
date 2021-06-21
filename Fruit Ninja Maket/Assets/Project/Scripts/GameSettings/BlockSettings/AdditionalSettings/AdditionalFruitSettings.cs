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
        
        private HalfFruitSettings halfSettings;
        private ScoreFruitSettings scoreSettings;
        
        private int countOfReducingLives;

        public Sprite LeftHalfOfSprite => leftHalfOfSprite;
        public Sprite RightHalfOfSprite => rightHalfOfSprite; 
        public Color SprayColor => fruitJuiceColor; 
        public int CountOfReducingLives => countOfReducingLives;
        public HalfFruitSettings HalfSettings => halfSettings;
        public ScoreFruitSettings ScoreSettings => scoreSettings;

        public void SetOtherSettings(HalfFruitSettings halfSettings, ScoreFruitSettings scoreSettings, int countOfReducingLives)
        {
            this.halfSettings = halfSettings;
            this.scoreSettings = scoreSettings;
            this.countOfReducingLives = countOfReducingLives;
        }
    }
}