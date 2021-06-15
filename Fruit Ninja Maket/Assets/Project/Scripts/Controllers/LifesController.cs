using Scripts.GameSettings;
using Scripts.GameSettings.LifesSettings;
using Scripts.UI.Lifes;
using UnityEngine;

namespace Scripts.Controllers
{
    public class LifesController : MonoBehaviour
    {
        [SerializeField]
        private LifesControllerSettings controllerSettings;

        [SerializeField]
        private LifesUI lifesUI;

        private int currentLifes;

        private void Start()
        {
            currentLifes = controllerSettings.MaxLifesCount;
            lifesUI.InitializeSettings(currentLifes);
        }

        public void RemoveLifes(Vector2 fruitPosition)
        {
            currentLifes -= controllerSettings.IncresingLifesValue;
            lifesUI.SetLifesCount(currentLifes);

            Vector2 screenPosition = Camera.main.WorldToScreenPoint(fruitPosition);
            CreateSceneFail(screenPosition);
        }

        public void CreateSceneFail(Vector2 position)
        {
            Instantiate(controllerSettings.SceneFailPrefab, position, Quaternion.identity, lifesUI.transform.parent);
        }
    }
}
