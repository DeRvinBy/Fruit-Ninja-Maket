using Scripts.Physics;
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

        private Vector2 previousPositionOfSlicingPath;
        private Vector2 currentPositionOfSlicingPath;

        private bool isSwipping;

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

            if (isSwipping)
            {
                var objects = ObjectCollider.GetObjectIntersectedWithPoint(GetMediaPointOfSlicingPath());
                foreach (var go in objects)
                {
                    Destroy(go);
                }
            }
        }

        private void UpdateSlicingPath(Touch touch)
        {
            if (!isSwipping)
            {
                previousPositionOfSlicingPath = mainCamera.ScreenToWorldPoint(touch.position);
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
                    currentPositionOfSlicingPath = mainCamera.ScreenToWorldPoint(touch.position);
                    Debug.DrawLine(previousPositionOfSlicingPath, currentPositionOfSlicingPath, Color.red, 2f);
                    previousPositionOfSlicingPath = currentPositionOfSlicingPath;
                }
                else
                {
                    isSwipping = false;
                }
            }           
        }

        public Vector3 GetMediaPointOfSlicingPath()
        {
            return Vector3.Lerp(previousPositionOfSlicingPath, currentPositionOfSlicingPath, MIDPOINT_RATIO);
        }

        public Vector3 GetDirectionOfSlicingPath()
        {
            return (currentPositionOfSlicingPath - previousPositionOfSlicingPath).normalized;
        }
    }
}
