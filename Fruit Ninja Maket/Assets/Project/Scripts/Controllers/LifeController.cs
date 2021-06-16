using Project.Scripts.GameSettings.LifeSettings;
using Project.Scripts.UI.Life;
using UnityEngine;

namespace Project.Scripts.Controllers
{
    public class LifeController : MonoBehaviour
    {
        private const int LoseLives = 0;

        [SerializeField]
        private GameController gameController = null;

        [SerializeField]
        private LifeControllerSettings controllerSettings = null;

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
            currentLives = controllerSettings.MaxLivesCount;
            lifeUI.InitializeSettings(currentLives);
            lifeUI.SetLivesCount(currentLives);
        }

        public void RemoveLives(Vector2 fruitPosition)
        {
            if (!isEndGame)
            {
                currentLives -= controllerSettings.IncreasingLivesValue;
                lifeUI.SetLivesCount(currentLives);
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
