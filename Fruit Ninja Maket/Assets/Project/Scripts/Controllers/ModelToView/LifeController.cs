using Project.Scripts.GameSettings.LifeSettings;
using Project.Scripts.UI.Life;
using UnityEngine;

namespace Project.Scripts.Controllers.ModelToView
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

        public bool IsFullLives => currentLives == controllerSettings.MaxLivesCount;
        
        private void Start()
        {
            mainCamera = Camera.main;
            Initialize();
        }

        public void Initialize()
        {
            isEndGame = false;
            currentLives = controllerSettings.MaxLivesCount;
            lifeUI.InitializeSettings(currentLives);
        }

        public void RemoveLivesWithSpawnFail(Vector2 position, int count)
        {
            if (isEndGame) return;
            
            RemoveLives(count);
            Vector2 screenPosition = mainCamera.WorldToScreenPoint(position);
            Instantiate(controllerSettings.SceneFailPrefab, screenPosition, Quaternion.identity, uiTransform);
        }
        
        public void RemoveLives(int count)
        {
            if (isEndGame) return;
            
            currentLives -= count;
            lifeUI.RemoveLive();
            if (currentLives <= LoseLives)
            {
                gameController.EndGame();
                isEndGame = true;
            }
        }

        public void AddLivesAnimate(Vector2 position, int count)
        {
            if (isEndGame) return;
            
            Vector2 screenPosition = mainCamera.WorldToScreenPoint(position);
            AddLives(count);
            lifeUI.AddLive(screenPosition);
        }
        
        private void AddLives(int count)
        {
            currentLives += count;
            if (currentLives > controllerSettings.MaxLivesCount)
            {
                currentLives = controllerSettings.MaxLivesCount;
            }
        }
    }
}
