using Project.Scripts.GameEntities;
using Scripts.Controllers;
using Scripts.GameSettings.FruitSettings;
using Scripts.GameSettings.FruitSettings.MonoSettings;
using Scripts.Physics;
using UnityEngine;

namespace Scripts.Spawn
{
    public class ObjectCreator : MonoBehaviour
    {
        private const int ZERO_COUNT_OBJECTS = 0;

        [SerializeField]
        private ScoreController scoreController = null;

        [SerializeField]
        private LifesController lifesController = null;

        [SerializeField]
        private FruitSettingsContainer fruitSettingsContainer = null;

        public bool IsExistObjectsOnScene { get => createdObjects != ZERO_COUNT_OBJECTS; }

        private int createdObjects;

        public void SetObjectsCountInBundle(int count)
        {
            createdObjects = count;
        }

        public void CreateFruit(Vector2 position, Vector2 direction, float velocity)
        {
            FruitSettings settings = fruitSettingsContainer.GetRandomFruitSettings();
            Fruit prefab = fruitSettingsContainer.FruitPrefab;
            Fruit go = Instantiate(prefab, position, Quaternion.identity);

            go.InitializeFruitSettings(settings, velocity);
            go.OnFruitSliced.AddListener(scoreController.AddScoreByFruit);
            go.OnFruitNotSliced.AddListener(lifesController.RemoveLifes);
            go.OnFruitDestroyed.AddListener(ReduceCreatedObjects);

            if (go.TryGetComponent(out PhysicalMovement movement))
            {
                movement.AddVelocity(direction * velocity);
            }
        }

        private void ReduceCreatedObjects()
        {
            createdObjects--;
        }
    }
}
