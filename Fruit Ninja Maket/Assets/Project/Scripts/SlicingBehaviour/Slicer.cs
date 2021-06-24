using Project.Scripts.Controllers;
using Project.Scripts.Controllers.Blocks;
using UnityEngine;

namespace Project.Scripts.SlicingBehaviour
{
    public class Slicer : MonoBehaviour
    {
        [SerializeField]
        private PlayerInput input = null;

        [SerializeField] 
        private BlockController blockController = null;
        
        private void Update()
        {
            if (!input.IsSwiping) return;
            
            var slicingPoint = input.GetMediaPointOfSlicingPath();
            var slicingDirection = input.GetDirectionOfSlicingPath();

            var intersectedObjects = blockController.GetBlocksIntersectedWithPoint(slicingPoint);

            foreach(var sliceBlock in intersectedObjects)
            {
                sliceBlock.Slice(slicingDirection);
            }
        }
    }
}