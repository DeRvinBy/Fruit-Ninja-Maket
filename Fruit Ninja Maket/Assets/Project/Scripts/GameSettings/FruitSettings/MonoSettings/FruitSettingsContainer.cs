using Scripts.GameEntities;
using UnityEngine;

namespace Scripts.GameSettings.FruitSettings.MonoSettings
{
    public class FruitSettingsContainer : MonoBehaviour
    {
        [SerializeField]
        private Fruit fruitPrefab = null;

        [SerializeField]
        private FruitBlot fruitBlotPrefab = null;

        [SerializeField]
        private float blotLifeTime = 2f;

        [SerializeField]
        private float halfsVelocityCoef = 2f;

        [SerializeField]
        private FruitSettings[] fruitSettings = null;

        public Fruit FruitPrefab { get => fruitPrefab; }

        public FruitSettings GetRandomFruitSettings()
        {
            int index = Random.Range(0, fruitSettings.Length);
            FruitSettings settings =  fruitSettings[index];
            settings.SetOtherSettings(fruitBlotPrefab, blotLifeTime, halfsVelocityCoef);
            return settings;
        }
    }
}
