using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.UI.Life
{
    public class LifeUI : MonoBehaviour
    {
        private List<LifeContainerUI> lifeContainers;

        private int currentIndex;
        
        public void InitializeSettings(int maxLivesCount)
        {
            lifeContainers = new List<LifeContainerUI>();

            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i).GetComponent<LifeContainerUI>();
                if (i < maxLivesCount)
                {
                    child.gameObject.SetActive(true);
                    child.SetActiveContainer();
                    lifeContainers.Add(child);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }

            currentIndex = lifeContainers.Count - 1;
        }

        public void AddLive(Vector2 animationPosition)
        {
            if(currentIndex + 1 >= lifeContainers.Count) return;
            
            currentIndex++;
            lifeContainers[currentIndex].ActivateLifeImage(animationPosition);
        }
        
        public void RemoveLive()
        {
            if(currentIndex < 0) return;
            
            lifeContainers[currentIndex].DeactivateLifeImage();
            currentIndex--;
        }
    }
}