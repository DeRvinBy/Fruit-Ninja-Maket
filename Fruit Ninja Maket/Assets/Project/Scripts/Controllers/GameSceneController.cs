using System.Collections;
using Project.Scripts.Controllers.ModelToView;
using Project.Scripts.SlicingBehaviour;
using Project.Scripts.Spawn;
using Project.Scripts.UI.Game;
using UnityEngine;

namespace Project.Scripts.Controllers
{
    public class GameSceneController : MonoBehaviour
    {
        [SerializeField]
        private SpawnController spawnController = null;

        [SerializeField]
        private PlayerInput playerInput = null;

        [SerializeField]
        private BlockController blockController = null;

        [SerializeField]
        private ScoreController scoreController = null;

        [SerializeField]
        private LifeController lifeController = null;

        [SerializeField]
        private RestartUI restartUI = null;

        public void StartGame()
        {
            ViewControllerInitialize();
            GameControllerInitialize();
        }
        
        public void EndGame()
        {            
            playerInput.SetEnableInput(false);
            spawnController.StopSpawnObjects();
            scoreController.SetBestScoreInSave();
            StartCoroutine(WaitToShowRestartPanel());
        }

        public void ViewControllerInitialize()
        {
            lifeController.Initialize();
            scoreController.Initialize();
        }

        public void GameControllerInitialize()
        {
            playerInput.SetEnableInput(true);
            spawnController.Initialize();
        }

        private IEnumerator WaitToShowRestartPanel()
        {
            yield return new WaitWhile(() => blockController.IsExistObjectsOnScene);
            restartUI.ShowRestartPanel(scoreController.CurrentScore, scoreController.BestScore);
        }
    }
}
