using System;
using UnityEngine;

namespace Scripts.Spawn
{
    [Serializable]
    public class SpawnsSettings
    {
        [SerializeField] 
        [Range(0f, 1f)]
        private float probability = 0.0f;

        [SerializeField]
        [Range(0f, 1f)]
        private float relativePostionX = 0f;

        [SerializeField]
        [Range(0f, 1f)]
        private float relativePostionY = 0f;

        [SerializeField]
        private SpawnZone spawnZone = null;

        public float Probability
        {
            get
            {
                return probability;
            }
            set
            {
                probability = value;
            }
        }

        public SpawnZone SpawnZone
        {
            get
            {
                return spawnZone;
            }
        }

        public void UpdateZonePositionByScreen(Vector3 topLeftCorner, Vector3 bottomRightCorner)
        {
            float x = Mathf.Lerp(topLeftCorner.x, bottomRightCorner.x, relativePostionX);
            float y = Mathf.Lerp(topLeftCorner.y, bottomRightCorner.y, relativePostionY);
            spawnZone.transform.position = new Vector3(x, y, 0);
        }
    }
}