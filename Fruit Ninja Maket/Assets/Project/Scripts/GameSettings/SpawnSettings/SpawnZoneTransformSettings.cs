using System;
using UnityEngine;

namespace Project.Scripts.GameSettings.SpawnSettings
{
    [Serializable]
    public class SpawnZoneTransformSettings
    {
        [SerializeField]
        [Range(0f, 1f)]
        private float relativePositionX = 0f;

        [SerializeField]
        [Range(0f, 1f)]
        private float relativePositionY = 0f;

        [SerializeField]
        [Range(0f, 1f)]
        private float relativeSize = 0f;

        public Vector3 GetRelativePosition(Vector3 topLeftCorner, Vector3 bottomRightCorner)
        {
            var positionX = Mathf.Lerp(topLeftCorner.x, bottomRightCorner.x, relativePositionX);
            var positionY = Mathf.Lerp(topLeftCorner.y, bottomRightCorner.y, relativePositionY);
            return new Vector3(positionX, positionY);
        }

        public Vector3 GetRelativeScale(Vector3 topLeftCorner, Vector3 bottomRightCorner)
        {
            var sizeX = Mathf.Lerp(topLeftCorner.x, bottomRightCorner.x, relativeSize);
            var sizeY = Mathf.Lerp(topLeftCorner.y, bottomRightCorner.y, relativeSize);
            return new Vector3(sizeX, sizeY);
        }
    }
}