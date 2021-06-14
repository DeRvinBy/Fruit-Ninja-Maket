using System.Collections;
using UnityEngine;

namespace Scripts.SlicingBehaviour
{
    public class SliceTrace : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput input;

        [SerializeField]
        private TrailRenderer trail;

        private Vector2 trailPosition;

        private void Update()
        {
            if (input.IsSwipping)
            {
                trailPosition = input.GetCurrentPointOfSlicingPath();
                transform.position = trailPosition;
            }
            else
            {
                StartCoroutine(DisableTrail());
            }
        }

        private IEnumerator DisableTrail()
        {
            trail.enabled = false;
            yield return new WaitWhile(() => !input.IsSwipping);
            trail.enabled = true;
        }
    }
}
