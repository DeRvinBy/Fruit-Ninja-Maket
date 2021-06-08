using UnityEngine;

namespace Scripts.Spawn
{
    public class SpawnBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Transform startBoundary = null;

        [SerializeField]
        private Transform endBoundary = null;

        public void SpawnObjectsOnScene(GameObject[] spawnObjects, float angle)
        {
            for(int i = 0; i < spawnObjects.Length; i++)
            {
                
            }
        }
    }
}