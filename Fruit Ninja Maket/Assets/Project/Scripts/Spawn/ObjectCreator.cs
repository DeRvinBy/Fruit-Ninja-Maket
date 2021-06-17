using Project.Scripts.Controllers;
using Project.Scripts.GameSettings.BlockSettings.MonoSettings;
using UnityEngine;

namespace Project.Scripts.Spawn
{
    public class ObjectCreator : MonoBehaviour
    {
        [SerializeField] 
        private BlockController blockController = null;
        
        [SerializeField]
        private ScoreController scoreController = null;

        [SerializeField]
        private LifeController lifeController = null;

        [SerializeField]
        private BlockSettingsContainer blockSettingsContainer = null;
        
        [SerializeField]
        private FruitSettingsContainer fruitSettingsContainer = null;
        
        public void CreateFruit(Vector2 position, Vector2 direction)
        {
            var settings = fruitSettingsContainer.GetRandomFruitSettings();
            var prefab = fruitSettingsContainer.FruitPrefab;
            var go = Instantiate(prefab, position, Quaternion.identity, transform);

            var velocity = direction * blockSettingsContainer.VelocityOfObjects;
            go.SetMovement(velocity);
            go.InitializeFruitSettings(settings);
            go.OnFruitSliced.AddListener(scoreController.AddScoreByFruit);
            go.OnFruitNotSliced.AddListener(lifeController.RemoveLives);
            go.OnBlockDestroyed.AddListener(blockController.RemoveBlock);
            blockController.AddBlock(go);
        }
    }
}
