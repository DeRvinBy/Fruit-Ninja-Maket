using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Controllers
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text scoreText = null;

        [SerializeField] 
        private int gameSceneIndex = 0;
        
        private void Start()
        {
            var score = SaveController.Instance.GetBestScore(); 
            scoreText.text = score.ToString();
        }

        public void StartGameScene()
        {
            SceneManager.LoadScene(gameSceneIndex);
        }
    }
}
