using Project.Scripts.Controllers;
using Project.Scripts.GameSettings.BlockSettings.MonoSettings;
using Project.Scripts.Physics;
using UnityEngine;

namespace Project.Scripts.Spawn
{
    public class ObjectCreator : MonoBehaviour
    {
        private const int ZeroCountObjects = 0;

        [SerializeField]
        private ScoreController scoreController = null;

        [SerializeField]
        private LifeController lifeController = null;

        [SerializeField]
        private BlockSettingsContainer blockSettingsContainer = null;
        
        [SerializeField]
        private FruitSettingsContainer fruitSettingsContainer = null;

        public bool IsExistObjectsOnScene => createdObjects > ZeroCountObjects;

        private int createdObjects;

        public void CreateFruit(Vector2 position, Vector2 direction)
        {
            var settings = fruitSettingsContainer.GetRandomFruitSettings();
            var prefab = fruitSettingsContainer.FruitPrefab;
            var go = Instantiate(prefab, position, Quaternion.identity, transform);

            go.InitializeFruitSettings(settings);
            go.OnFruitSliced.AddListener(scoreController.AddScoreByFruit);
            go.OnFruitNotSliced.AddListener(lifeController.RemoveLives);
            go.OnFruitDestroyed.AddListener(ReduceCreatedObjects);

            if (go.TryGetComponent(out PhysicalMovement movement))
            {
                movement.AddVelocity(direction * blockSettingsContainer.VelocityOfObjects);
            }

            createdObjects++;
        }

        private void ReduceCreatedObjects()
        {
            createdObjects--;
        }
    }
}
