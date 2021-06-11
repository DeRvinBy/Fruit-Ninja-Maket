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
        private FruitSettingsContainer fruitSettingsContainer = null;

        public void CreateFruit(Vector2 position, Vector2 velocity)
        {
            FruitSettings settings = fruitSettingsContainer.GetRandomFruitSettings();
            Fruit prefab = fruitSettingsContainer.FruitPrefab;
            Fruit go = Instantiate(prefab, position, Quaternion.identity);

            go.InitializeFruitSettings(settings);

            if(go.TryGetComponent(out PhysicalMovement movement))
            {
                movement.AddVelocity(velocity);
            }
        }
    }
}
