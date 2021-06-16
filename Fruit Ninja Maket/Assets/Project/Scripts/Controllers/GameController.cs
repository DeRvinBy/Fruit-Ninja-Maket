using System.Collections;
using Project.Scripts.SlicingBehaviour;
using Project.Scripts.Spawn;
using Project.Scripts.UI.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private SpawnController spawnController = null;

        [SerializeField]
        private PlayerInput playerInput = null;

        [SerializeField]
        private ObjectCreator objectCreator = null;

        [SerializeField]
        private ScoreController scoreController = null;

        [SerializeField]
        private LifeController lifeController = null;

        [SerializeField]
        private RestartUI restartUI = null;

        [SerializeField] 
        private int menuSceneIndex = 0;
        
        private void Start()
        {
            StartScene();
        }

        public void EndGame()
        {            
            playerInput.SetEnableInput(false);
            spawnController.StopSpawnObjects();
            StartCoroutine(WaitToDestroyObjects());
        }
        
        public void StartMenuScene()
        {
            SceneManager.LoadScene(menuSceneIndex);
        }

        public void StartScene()
        {
            playerInput.SetEnableInput(true);
            spawnController.Initialize();
            lifeController.Initialize();
            scoreController.Initialize();
        }

        private IEnumerator WaitToDestroyObjects()
        {
            yield return new WaitWhile(() => objectCreator.IsExistObjectsOnScene);
            restartUI.ShowRestartPanel(scoreController.CurrentScore, scoreController.BestScore);
        }
    }
}
