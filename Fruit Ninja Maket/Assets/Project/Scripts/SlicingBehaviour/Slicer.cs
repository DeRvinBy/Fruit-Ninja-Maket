using Scripts.GameEntities;
using Scripts.Physics;
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

                var intersectedObjects = ObjectCollider.GetObjectsIntersectedWithPoint(slicingPoint);
                print(intersectedObjects.Count);
                foreach(var obj in intersectedObjects)
                {
                    if(obj.TryGetComponent(out Fruit fruit))
                    {
                        fruit.Slice();
                    }
                }
            }
        }
    }
}