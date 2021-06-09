using UnityEngine;

namespace Scripts.CuttingBehaviour
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField]
        private float minDistanceOfCutting = 5f;

        [SerializeField]
        private float minSpeedOfCutting = 2f;

        private Vector2 startPosition;
        private Vector2 nextPosition;

        private bool isSwipping;

        private void Update()
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                float swipeDeltaDistance = 0f;

                switch(touch.phase)
                {
                    case TouchPhase.Began:                   
                        startPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        break;
                    case TouchPhase.Moved:
                        isSwipping = true;
                        swipeDeltaDistance = Camera.main.ScreenToWorldPoint(touch.deltaPosition).magnitude;
                        print(swipeDeltaDistance);
                        nextPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        break;
                    case TouchPhase.Ended:
                        isSwipping = false;
                        break;
                }

                if (isSwipping)
                {                   
                    float currentSpeed = swipeDeltaDistance / touch.deltaTime;
                    if(currentSpeed > minSpeedOfCutting)
                    {
                        float deltaDistance = (nextPosition - startPosition).magnitude;
                        if (deltaDistance > minDistanceOfCutting)
                        {
                            Debug.DrawLine(startPosition, nextPosition, Color.red, 2f);
                            startPosition = nextPosition;
                        }
                    }
                    else
                    {
                        isSwipping = false;
                    }

                }
            }
            else
            {
                isSwipping = false;
            }
        }
    }
}
