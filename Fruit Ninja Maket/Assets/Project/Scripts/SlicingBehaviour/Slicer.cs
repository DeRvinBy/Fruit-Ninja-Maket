using System;
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
        private ControllersManager controllersManager = null;

        private BlockController blockController;
        
        private void Start()
        {
            blockController = controllersManager.GetBlockController();
        }

        private void Update()
        {
            if (!input.IsSwiping) return;
            
            var slicingPoint = input.GetMediaPointOfSlicingPath();
            var slicingDirection = input.GetDirectionOfSlicingPath();

            blockController.SliceBlocksIntersectedWithPoint(slicingPoint, slicingDirection);
        }
    }
}