using UnityEngine;

namespace Scripts.Spawn
{
    public class SpawnBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Transform startBoundary = null;

        [SerializeField]
        private Transform endBoundary = null;

        public void SpawnObjects(GameObject[] spawnObjects)
        {
            for(int i = 0; i < spawnObjects.Length; i++)
            {
                
            }
        }
    }
}