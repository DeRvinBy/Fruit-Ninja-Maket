using System.Collections.Generic;
using Project.Scripts.GameEntities;
using Project.Scripts.Physics;
using UnityEngine;

namespace Project.Scripts.SlicingBehaviour
{
    public class Slicer : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput input = null;

        private void Update()
        {
            if (!input.IsSwiping) return;
            
            var slicingPoint = input.GetMediaPointOfSlicingPath();
            var slicingDirection = input.GetDirectionOfSlicingPath();

            var intersectedObjects = ObjectCollider.GetObjectsIntersectedWithPoint(slicingPoint);

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