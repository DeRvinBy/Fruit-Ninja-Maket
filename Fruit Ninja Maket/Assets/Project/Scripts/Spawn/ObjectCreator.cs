using Scripts.Controllers;
using Scripts.GameEntities;
using Scripts.GameSettings.FruitSettings;
using Scripts.GameSettings.FruitSettings.MonoSettings;
using Scripts.Physics;
using UnityEngine;

namespace Scripts.Spawn
{
    public class ObjectCreator : MonoBehaviour
    {
        [SerializeField]
        private ScoreController scoreController = null;

        [SerializeField]
        private LifesController lifesController = null;

        [SerializeField]
        private FruitSettingsContainer fruitSettingsContainer = null;

        public void CreateFruit(Vector2 position, Vector2 direction, float velocity)
        {
            FruitSettings settings = fruitSettingsContainer.GetRandomFruitSettings();
            Fruit prefab = fruitSettingsContainer.FruitPrefab;
            Fruit go = Instantiate(prefab, position, Quaternion.identity);

            go.InitializeFruitSettings(settings, velocity);
            go.OnFruitSliced.AddListener(scoreController.AddScoreByFruit);
            go.OnFruitDestroyed.AddListener(lifesController.RemoveLifes);

            if (go.TryGetComponent(out PhysicalMovement movement))
            {
                movement.AddVelocity(direction * velocity);
            }
        }
    }
}
