using System.Collections;
using UnityEngine;

namespace Project.Scripts.SlicingBehaviour
{
    public class SliceTrace : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput input;

        [SerializeField]
        private TrailRenderer trail;

        private bool isStartShowTrail;
        
        private void LateUpdate()
        {
            EnableEmitting();
            UpdateSliceTrace();
        }

        private void EnableEmitting()
        {
            if (isStartShowTrail)
            {
                trail.emitting = true;
                isStartShowTrail = false;
            }
        }
        
        private void UpdateSliceTrace()
        {
            if (input.IsSwiping)
            {
                var trailPosition = input.GetCurrentPointOfSlicingPath();
                transform.position = trailPosition;
                if (!trail.emitting)
                {
                    isStartShowTrail = true;
                }
            }
            else
            {
                trail.emitting = false;
            }
        }
    }
}
