using UnityEngine;

namespace Project.Scripts.UI.Life
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
