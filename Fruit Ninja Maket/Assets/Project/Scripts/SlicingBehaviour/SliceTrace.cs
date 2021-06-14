using UnityEngine;

namespace Scripts.SlicingBehaviour
{
    public class SliceTrace : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput input;

        [SerializeField]
        private TrailRenderer trail;

        private void LateUpdate()
        {
            if (input.IsSwipping)
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
            Vector2 trailPosition = input.GetCurrentPointOfSlicingPath();
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
