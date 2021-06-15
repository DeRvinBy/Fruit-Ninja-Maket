using UnityEngine;

namespace Scripts.UI.Lifes
{
    public class LifeContainerUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject lifeImage = null;

        public void SetActiveLifeImage(bool active)
        {
            lifeImage.SetActive(active);
        }
    }
}
