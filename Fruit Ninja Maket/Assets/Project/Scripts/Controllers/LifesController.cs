using Scripts.GameSettings;
using Scripts.GameSettings.LifesSettings;
using Scripts.UI.Lifes;
using UnityEngine;

namespace Scripts.Controllers
{
    public class LifesController : MonoBehaviour
    {
        private const int LOSE_LIFES = 0;

        [SerializeField]
        private GameController gameController = null;

        [SerializeField]
        private LifesControllerSettings controllerSettings = null;

        [SerializeField]
        private LifesUI lifesUI = null;

        private int currentLifes;
        private bool isEndGame;

        private void Start()
        {
            currentLifes = controllerSettings.MaxLifesCount;
            lifesUI.InitializeSettings(currentLifes);
        }

        public void RemoveLifes(Vector2 fruitPosition)
        {
            if (!isEndGame)
            {
                currentLifes -= controllerSettings.IncresingLifesValue;
                lifesUI.SetLifesCount(currentLifes);
                if (currentLifes <= LOSE_LIFES)
                {
                    gameController.EndGame();
                    isEndGame = true;
                }

                Vector2 screenPosition = Camera.main.WorldToScreenPoint(fruitPosition);
                CreateSceneFail(screenPosition);
            }
        }

        public void CreateSceneFail(Vector2 position)
        {
            Instantiate(controllerSettings.SceneFailPrefab, position, Quaternion.identity, lifesUI.transform.parent);
        }
    }
}
