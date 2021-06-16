using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Controllers
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text score = null;

        [SerializeField] 
        private int gameSceneIndex = 0;
        
        private void Start()
        {
            score.text = "100";
        }

        public void StartGameScene()
        {
            SceneManager.LoadScene(gameSceneIndex);
        }
    }
}
