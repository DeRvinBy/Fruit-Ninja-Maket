using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.UI.Life
{
    public class LifeUI : MonoBehaviour
    {
        private List<LifeContainerUI> lifeContainers;
        
        private int currentIndex;

        public void CreateLifeContainers(LifeContainerUI prefab, int maxLivesCount)
        {
            lifeContainers = new List<LifeContainerUI>();

            for (int i = 0; i < maxLivesCount; i++)
            {
                var container = Instantiate(prefab, transform);
                lifeContainers.Add(container);
            }
        }

        public void InitializeContainers()
        {
            foreach (var container in lifeContainers)
            {
                container.ActivateContainer();
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