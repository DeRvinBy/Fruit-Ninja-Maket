using Project.Scripts.Controllers.Save;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Controllers
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text scoreText = null;

        private void Start()
        {
            var score = SaveController.Instance.PlayerSave.BestScore; 
            scoreText.text = score.ToString();
        }
    }
}
