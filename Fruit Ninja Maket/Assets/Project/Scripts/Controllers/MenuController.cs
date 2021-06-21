using Project.Scripts.Controllers.Save;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Controllers
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] 
        private ResourceManager resourceManager = null;
        
        [SerializeField] 
        private TMP_Text scoreText = null;

        private ISaveController saveController;
        
        public void StartMenuScene()
        {
            var score = 0;
            if ((saveController = resourceManager.GetSaveController()) != null)
            {
                score = saveController.PlayerSave.BestScore;
            }

            scoreText.text = score.ToString();
        }
    }
}
