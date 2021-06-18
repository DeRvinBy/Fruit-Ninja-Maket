using System;
using UnityEngine;

namespace Project.Scripts.SlicingBehaviour
{
    public class PlayerInput : MonoBehaviour
    {
        private const int LeftMouseButton = 0;
        private const float MidpointRatio = 0.5f;

        [SerializeField]
        private float minDistanceOfSlicing = 5f;

        [SerializeField]
        private float minSpeedOfSlicing = 2f;

        private Camera mainCamera;
        
        private Vector2 previousPointOfInput;

        private Vector2 previousPointOfSlicingPath;
        private Vector2 currentPointOfSlicingPath;

        private bool isInputEnable;
        private bool isSwiping;

        public bool IsSwiping => isSwiping && isInputEnable;

        private void Start()
        {
            mainCamera = Camera.main;
        }
        
        private void Update()
        {
            if (!isInputEnable)
            {
                return;
            }

            if (Input.GetMouseButtonDown(LeftMouseButton))
            {
                SetStartPoints();
            }
            else if (Input.GetMouseButton(LeftMouseButton))
            {
                SetCurrentPoint();
                UpdatePoints();
            }
            else
            {
                isSwiping = false;
            }
        }

        public void SetEnableInput(bool isEnable)
        {
            isInputEnable = isEnable;
        }

        public Vector2 GetMediaPointOfSlicingPath()
        {
            return Vector3.Lerp(previousPointOfSlicingPath, currentPointOfSlicingPath, MidpointRatio);
        }

        public Vector2 GetDirectionOfSlicingPath()
        {
            return (currentPointOfSlicingPath - previousPointOfSlicingPath).normalized;
        }

        public Vector2 GetCurrentPointOfSlicingPath()
        {
            return currentPointOfSlicingPath;
        }

        private void SetStartPoints()
        {
            previousPointOfSlicingPath = GetWorldMousePosition();
            previousPointOfInput = previousPointOfSlicingPath;
        }

        private void SetCurrentPoint()
        {
            currentPointOfSlicingPath = GetWorldMousePosition();
        }

        private Vector2 GetWorldMousePosition()
        {
            return mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        private void UpdatePoints()
        {
            var slicingDistance = (previousPointOfSlicingPath - currentPointOfSlicingPath).magnitude;
            var speedDistance = (previousPointOfInput - currentPointOfSlicingPath).magnitude;
            var speed = speedDistance / Time.deltaTime;

            isSwiping = speed > minSpeedOfSlicing && slicingDistance > minDistanceOfSlicing;

            if (isSwiping)
            {
                previousPointOfSlicingPath = currentPointOfSlicingPath;
            }

            previousPointOfInput = currentPointOfSlicingPath;
        }
    }
}
