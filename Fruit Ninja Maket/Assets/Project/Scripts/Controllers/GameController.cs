using Scripts.SlicingBehaviour;
using Scripts.Spawn;
using Scripts.UI.Game;
using System.Collections;
using UnityEngine;

namespace Scripts.Controllers
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
        private LifesController lifesController = null;

        [SerializeField]
        private RestartUI restartUI = null;

        private void Start()
        {
            StartScene();
        }

        public void EndGame()
        {            
            spawnController.StopSpawnObjects();
            playerInput.SetEnableInput(false);
            StartCoroutine(WaitToDestroyObjects());
        }

        public void StartScene()
        {
            spawnController.Initialize();
            playerInput.SetEnableInput(true);
            lifesController.Initialize();
            scoreController.Initialize();
        }

        private IEnumerator WaitToDestroyObjects()
        {
            yield return new WaitWhile(() => objectCreator.IsExistObjectsOnScene);
            restartUI.ShowRestartPanel(scoreController.CurrentScore, scoreController.BestScore);
        }
    }
}
