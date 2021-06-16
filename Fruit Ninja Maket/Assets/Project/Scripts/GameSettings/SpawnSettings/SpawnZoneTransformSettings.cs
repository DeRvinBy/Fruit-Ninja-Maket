using System;
using UnityEngine;

namespace Scripts.GameSettings.SpawnSettings
{
    [Serializable]
    public class SpawnZoneTransformSettings
    {
        [SerializeField]
        [Range(0f, 1f)]
        private float relativePostionX = 0f;

        [SerializeField]
        [Range(0f, 1f)]
        private float relativePostionY = 0f;

        [SerializeField]
        [Range(0f, 1f)]
        private float relativeSize = 0f;

        public Vector3 GetRelativePosition(Vector3 topLeftCorner, Vector3 bottomRightCorner)
        {
            float positionX = Mathf.Lerp(topLeftCorner.x, bottomRightCorner.x, relativePostionX);
            float positionY = Mathf.Lerp(topLeftCorner.y, bottomRightCorner.y, relativePostionY);
            return new Vector3(positionX, positionY);
        }

        public Vector3 GetRelativeScale(Vector3 topLeftCorner, Vector3 bottomRightCorner)
        {
            float sizeX = Mathf.Lerp(topLeftCorner.x, bottomRightCorner.x, relativeSize);
            float sizeY = Mathf.Lerp(topLeftCorner.y, bottomRightCorner.y, relativeSize);
            return new Vector3(sizeX, sizeY);
        }
    }
}