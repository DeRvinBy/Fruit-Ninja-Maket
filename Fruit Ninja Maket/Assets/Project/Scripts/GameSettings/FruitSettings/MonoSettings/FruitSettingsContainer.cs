using Project.Scripts.GameEntities;
using UnityEngine;

namespace Project.Scripts.GameSettings.FruitSettings.MonoSettings
{
    public class FruitSettingsContainer : MonoBehaviour
    {
        [SerializeField]
        private Fruit fruitPrefab = null;

        [SerializeField]
        private float halfsVelocityCoefficient = 0.4f;

        [SerializeField]
        private FruitSettings[] fruitSettings = null;

        public Fruit FruitPrefab => fruitPrefab;

        public FruitSettings GetRandomFruitSettings()
        {
            var index = Random.Range(0, fruitSettings.Length);
            var settings = fruitSettings[index];
            settings.SetOtherSettings(halfsVelocityCoefficient);
            return settings;
        }
    }
}
