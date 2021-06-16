using UnityEngine;

namespace Project.Scripts.SlicingBehaviour
{
    public class SliceTrace : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput input;

        [SerializeField]
        private TrailRenderer trail;

        private void LateUpdate()
        {
            if (input.IsSwiping)
            {
                UpdateSliceTrace();
            }
            else
            {
                trail.emitting = false;
            }
        }

        private void UpdateSliceTrace()
        {
            var trailPosition = input.GetCurrentPointOfSlicingPath();
            if (trail.emitting)
            {
                transform.position = trailPosition;
            }
            else
            {
                trail.AddPosition(trailPosition);
                trail.emitting = true;
            }
        }
    }
}
