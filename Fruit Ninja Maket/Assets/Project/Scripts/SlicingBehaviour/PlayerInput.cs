using UnityEngine;

namespace Scripts.SlicingBehaviour
{
    public class PlayerInput : MonoBehaviour
    {
        private const float MIDPOINT_RATIO = 0.5f;

        [SerializeField]
        private float minDistanceOfSlicing = 5f;

        [SerializeField]
        private float minSpeedOfSlicing = 2f;

        private Camera mainCamera;

        private Vector2 previousPointOfSlicingPath;
        private Vector2 currentPointOfSlicingPath;

        private bool isSwipping;

        public bool IsSwipping { get => isSwipping; }

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    UpdateSlicingPath(touch);
                }       
            }
            else
            {
                isSwipping = false;
            }
        }

        private void UpdateSlicingPath(Touch touch)
        {
            if (!isSwipping)
            {
                previousPointOfSlicingPath = mainCamera.ScreenToWorldPoint(touch.position);
                isSwipping = true;
            }
            else
            {
                Vector2 currentWorldTouchPosition = mainCamera.ScreenToWorldPoint(touch.position);
                Vector2 previousWorldTouchPosition = mainCamera.ScreenToWorldPoint(touch.position - touch.deltaPosition);

                float distance = (currentWorldTouchPosition - previousWorldTouchPosition).magnitude;
                float speed = distance / touch.deltaTime;

                if (speed > minSpeedOfSlicing && distance > minDistanceOfSlicing)
                {
                    currentPointOfSlicingPath = mainCamera.ScreenToWorldPoint(touch.position);
                    Debug.DrawLine(previousPointOfSlicingPath, currentPointOfSlicingPath, Color.red, 2f);
                    previousPointOfSlicingPath = currentPointOfSlicingPath;
                }
                else
                {
                    isSwipping = false;
                }
            }           
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
    }
}
