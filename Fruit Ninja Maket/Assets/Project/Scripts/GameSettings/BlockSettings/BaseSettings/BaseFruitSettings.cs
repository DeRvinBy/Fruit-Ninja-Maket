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
        [SerializeField]
        private Fruit fruitPrefab = null;

        [SerializeField]
        private float halfVelocityCoefficient = 0.4f;

        [SerializeField]
        private AdditionalFruitSettings[] fruitSettings = null;

        public Fruit FruitPrefab => fruitPrefab;

        public AdditionalFruitSettings GetRandomFruitSettings()
        {
            var settings = fruitSettings.GetRandomItem();
            settings.SetOtherSettings(halfVelocityCoefficient);
            return settings;
        }
    }
}
