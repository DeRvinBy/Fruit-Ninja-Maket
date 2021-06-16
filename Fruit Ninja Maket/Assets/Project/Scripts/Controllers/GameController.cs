using System.Collections;
using Project.Scripts.Animations.UIAnimations;
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
        private SceneTransition sceneTransition = null;
        
        [SerializeField]
        private RestartUI restartUI = null;

        [SerializeField] 
        private int menuSceneIndex = 0;
        
        private void Start()
        {
            sceneTransition.HideTransition(StartScene);
        }

        public void StartScene()
        {
            playerInput.SetEnableInput(true);
            spawnController.Initialize();
            lifeController.Initialize();
            scoreController.Initialize();
        }
        
        public void EndGame()
        {            
            playerInput.SetEnableInput(false);
            spawnController.StopSpawnObjects();
            scoreController.SetBestScoreInSave();
            StartCoroutine(WaitToDestroyObjects());
        }
        
        public void StartMenuScene()
        {
            sceneTransition.ShowTransition(LoadMenuScene);
        }

        private void LoadMenuScene()
        {
            SceneManager.LoadScene(menuSceneIndex);
        }

        private IEnumerator WaitToDestroyObjects()
        {
            yield return new WaitWhile(() => objectCreator.IsExistObjectsOnScene);
            restartUI.ShowRestartPanel(scoreController.CurrentScore, scoreController.BestScore);
        }
    }
}
