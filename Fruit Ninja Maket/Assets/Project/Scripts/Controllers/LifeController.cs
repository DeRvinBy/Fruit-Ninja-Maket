using Scripts.GameSettings.LifesSettings;
using Scripts.UI.Lifes;
using UnityEngine;

namespace Project.Scripts.Controllers
{
    public class LifeController : MonoBehaviour
    {
        private const int LoseLives = 0;

        [SerializeField]
        private GameController gameController = null;

        [SerializeField]
        private LifesControllerSettings controllerSettings = null;

        [SerializeField]
        private Transform uiTransform = null;

        [SerializeField]
        private LifeUI lifeUI = null;

        private Camera mainCamera;
        
        private int currentLives;
        private bool isEndGame;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        public void Initialize()
        {
            currentLives = controllerSettings.MaxLifesCount;
            lifeUI.InitializeSettings(currentLives);
            lifeUI.SetLifesCount(currentLives);
        }

        public void RemoveLives(Vector2 fruitPosition)
        {
            if (!isEndGame)
            {
                currentLives -= controllerSettings.IncresingLifesValue;
                lifeUI.SetLifesCount(currentLives);
                if (currentLives <= LoseLives)
                {
                    gameController.EndGame();
                    isEndGame = true;
                }

                Vector2 screenPosition = mainCamera.WorldToScreenPoint(fruitPosition);
                CreateSceneFail(screenPosition);
            }
        }

        public void CreateSceneFail(Vector2 position)
        {
            Instantiate(controllerSettings.SceneFailPrefab, position, Quaternion.identity, uiTransform);
        }
    }
}
