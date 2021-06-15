using Scripts.SlicingBehaviour;
using Scripts.Spawn;
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



        public void EndGame()
        {            
            spawnController.StopSpawnObjects();
            playerInput.DisableInput();
            StartCoroutine(WaitToDestroyObjects());
        }

        private IEnumerator WaitToDestroyObjects()
        {
            yield return new WaitWhile(() => objectCreator.IsExistObjectsOnScene);
            print("Restart");
        }
    }
}
