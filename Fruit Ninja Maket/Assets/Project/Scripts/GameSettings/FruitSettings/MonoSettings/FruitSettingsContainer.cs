using UnityEngine;

namespace Scripts.GameSettings.FruitSettings.MonoSettings
{
    public class FruitSettingsContainer : MonoBehaviour
    {
        [SerializeField]
        private FruitSettings[] fruitSettings;

        public FruitSettings GetRandomFruitSettings()
        {
            int index = Random.Range(0, fruitSettings.Length);
            return fruitSettings[index];
        }
    }
}
