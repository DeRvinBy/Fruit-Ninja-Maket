using System;
using Project.Scripts.Blocks;
using Project.Scripts.Extensions;
using Project.Scripts.GameSettings.BlockSettings.AdditionalSettings;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.BaseSettings
{
    [Serializable]
    public class BaseFruitSettings : BaseBlockSettings
    {
        [Header("Fruit settings")]
        [SerializeField]
        private Fruit prefab = null;

        [SerializeField] 
        private HalfFruitSettings halfSettings = null;

        [SerializeField] 
        private ScoreFruitSettings scoreSettings = null;
        
        [SerializeField]
        private AdditionalFruitSettings[] fruitSettings = null;

        public Fruit Prefab => prefab;

        public AdditionalFruitSettings GetRandomFruitSettings()
        {
            var settings = fruitSettings.GetRandomItem();
            settings.SetOtherSettings(halfSettings, scoreSettings, countOfReducingLives);
            return settings;
        }
    }
}
