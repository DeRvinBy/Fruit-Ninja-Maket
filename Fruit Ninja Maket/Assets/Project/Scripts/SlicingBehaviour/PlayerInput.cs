using UnityEngine;

namespace Scripts.SlicingBehaviour
{
    public class PlayerInput : MonoBehaviour
    {
        private const int LEFT_MOUSE_BUTTON = 0;
        private const float MIDPOINT_RATIO = 0.5f;

        [SerializeField]
        private float minDistanceOfSlicing = 5f;

        [SerializeField]
        private float minSpeedOfSlicing = 2f;

        private Camera mainCamera;

        private Vector2 previousPointOfInput;

        private Vector2 previousPointOfSlicingPath;
        private Vector2 currentPointOfSlicingPath;

        private bool isSwipping;

        public bool IsSwipping { get => isSwipping; }

        private void Start()
        {
            mainCamera = Camera.main;
        }

        public Vector2 GetMediaPointOfSlicingPath()
        {
            return Vector3.Lerp(previousPointOfSlicingPath, currentPointOfSlicingPath, MIDPOINT_RATIO);
        }

        public Vector2 GetDirectionOfSlicingPath()
        {
            return (currentPointOfSlicingPath - previousPointOfSlicingPath).normalized;
        }

        public Vector2 GetCurrentPointOfSlicingPath()
        {
            return currentPointOfSlicingPath;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON))
            {
                SetStartPoints();
            }
            else if (Input.GetMouseButton(LEFT_MOUSE_BUTTON))
            {
                SetCurrentPoint();
                UpdatePoints();
            }
            else
            {
                isSwipping = false;
            }
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
            float slicingDistance = (previousPointOfSlicingPath - currentPointOfSlicingPath).magnitude;
            float speedDistance = (previousPointOfInput - currentPointOfSlicingPath).magnitude;
            float speed = speedDistance / Time.deltaTime;

            isSwipping = speed > minSpeedOfSlicing && slicingDistance > minDistanceOfSlicing;

            if (isSwipping)
            {
                previousPointOfSlicingPath = currentPointOfSlicingPath;
            }

            previousPointOfInput = currentPointOfSlicingPath;
        }
    }
}
