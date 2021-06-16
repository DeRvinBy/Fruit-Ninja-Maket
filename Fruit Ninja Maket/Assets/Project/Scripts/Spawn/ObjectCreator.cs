using Project.Scripts.Controllers;
using Project.Scripts.GameSettings.FruitSettings.MonoSettings;
using Scripts.Physics;
using UnityEngine;

namespace Scripts.Spawn
{
    public class ObjectCreator : MonoBehaviour
    {
        private const int ZeroCountObjects = 0;

        [SerializeField]
        private ScoreController scoreController = null;

        [SerializeField]
        private LifeController lifeController = null;

        [SerializeField]
        private FruitSettingsContainer fruitSettingsContainer = null;

        public bool IsExistObjectsOnScene => createdObjects != ZeroCountObjects;

        private int createdObjects;

        public void SetObjectsCountInBundle(int count)
        {
            createdObjects = count;
        }

        public void CreateFruit(Vector2 position, Vector2 direction, float velocity)
        {
            var settings = fruitSettingsContainer.GetRandomFruitSettings();
            var prefab = fruitSettingsContainer.FruitPrefab;
            var go = Instantiate(prefab, position, Quaternion.identity);

            go.InitializeFruitSettings(settings, velocity);
            go.OnFruitSliced.AddListener(scoreController.AddScoreByFruit);
            go.OnFruitNotSliced.AddListener(lifeController.RemoveLives);
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
