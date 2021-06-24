using System.Collections.Generic;
using Project.Scripts.Blocks;
using UnityEngine;

namespace Project.Scripts.Controllers.Blocks
{
    public class BlockController : MonoBehaviour
    {
        private const int ZeroCountObjects = 0;
        
        private readonly List<SliceBlock> blocks = new List<SliceBlock>();
        
        private int createdObjects;
        
        public bool IsExistObjectsOnScene => createdObjects > ZeroCountObjects;

        public void AddBlock(SliceBlock block)
        {
            blocks.Add(block);
            createdObjects++;
        }

        public void RemoveBlock(SliceBlock block)
        {
            blocks.Remove(block);
            createdObjects--;
        }

        public List<SliceBlock> GetBlocksIntersectedWithPoint(Vector2 point)
        {
            var result = new List<SliceBlock>();
            foreach(var block in blocks)
            {
                if(block.IsIntersectWithPoint(point))
                {
                    result.Add(block);
                }
            }
            
            return result;
        }

        public List<SliceBlock> GetBlocksInRadius(Vector2 center, float radius)
        {
            var result = new List<SliceBlock>();
            foreach(var block in blocks)
            {
                if(block.IsInRadiusFromPoint(center, radius))
                {
                    result.Add(block);
                }
            }

            return result;
        }
    }
}