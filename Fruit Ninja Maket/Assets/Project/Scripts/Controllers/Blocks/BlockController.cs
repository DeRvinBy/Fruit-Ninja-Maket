using System.Collections.Generic;
using Project.Scripts.Blocks;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
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

        public void SliceBlocksIntersectedWithPoint(Vector2 point, Vector2 slicingDirection)
        {
            for (var i = 0; i < blocks.Count; i++)
            {
                var block = blocks[i];
                if (block.IsIntersectWithPoint(point))
                {
                    block.Slice(slicingDirection);
                }
            }
        }

        public void PushBlocksFromBomb(Vector2 center, BaseBombSettings bombSettings)
        {
            for (var i = 0; i < blocks.Count; i++)
            {
                var block = blocks[i];
                if (block.IsInRadiusFromPoint(center, bombSettings.ExplosionRadius))
                {
                    var direction = block.transform.position - transform.position;
                    var distance = direction.magnitude;
                    var forceCoef = distance / bombSettings.ExplosionRadius;
                    block.SetMovement(direction.normalized * (bombSettings.ExplosionForce * forceCoef));
                }
            }
        }
    }
}