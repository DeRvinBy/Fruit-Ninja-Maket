using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.UI.Life
{
    public class LifeUI : MonoBehaviour
    {
        private List<LifeContainerUI> lifeContainers;

        public void InitializeSettings(int maxLivesCount)
        {
            lifeContainers = new List<LifeContainerUI>();

            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i).GetComponent<LifeContainerUI>();
                if (i < maxLivesCount)
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

        public void SetLivesCount(int value)
        {
            for(int i = 0; i < lifeContainers.Count; i++)
            {
                lifeContainers[i].SetActiveLifeImage(i < value);
            }
        }
    }
}