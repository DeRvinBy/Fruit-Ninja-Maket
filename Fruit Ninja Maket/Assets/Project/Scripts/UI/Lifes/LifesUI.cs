using System.Collections.Generic;
using UnityEngine;

namespace Scripts.UI.Lifes
{
    public class LifesUI : MonoBehaviour
    {
        private List<LifeContainerUI> lifeContainers;

        public void InitializeSettings(int maxLifesCount)
        {
            lifeContainers = new List<LifeContainerUI>();

            for (int i = 0; i < transform.childCount; i++)
            {
                LifeContainerUI child = transform.GetChild(i).GetComponent<LifeContainerUI>();
                if (i < maxLifesCount)
                {
                    child.gameObject.SetActive(true);
                    lifeContainers.Add(child);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
        }

        public void SetLifesCount(int value)
        {
            for(int i = 0; i < lifeContainers.Count; i++)
            {
                lifeContainers[i].SetActiveLifeImage(i < value);
            }
        }
    }
}