using Scripts.GameEntities;
using Scripts.Physics;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.SlicingBehaviour
{
    public class Slicer : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput input = null;

        private void Update()
        {
            if(input.IsSwipping)
            {
                Vector2 slicingPoint = input.GetMediaPointOfSlicingPath();
                Vector2 slicingDirection = input.GetDirectionOfSlicingPath();

                List<GameObject> intersectedObjects = ObjectCollider.GetObjectsIntersectedWithPoint(slicingPoint);

                foreach(var obj in intersectedObjects)
                {
                    if(obj.TryGetComponent(out Fruit fruit))
                    {
                        fruit.Slice(slicingDirection);
                    }
                }
            }
        }
    }
}