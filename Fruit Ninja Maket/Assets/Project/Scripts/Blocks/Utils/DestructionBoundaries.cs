using UnityEngine;

namespace Project.Scripts.Blocks.Utils
{
    public class DestructionBoundaries
    {
        private const float DestructionOffset = 1f;
        
        public float Down { get; private set; }
        public float Left { get; private set; }
        public float Right { get; private set; }

        public DestructionBoundaries(Camera camera)
        {
            Down = camera.ScreenToWorldPoint(new Vector2(0, 0)).y;
            Left = camera.ScreenToWorldPoint(new Vector2(0, 0)).x;
            Right = camera.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        }
        
        public bool IsOutOfBorder(Vector3 position)
        {
            var isDownBorderOut = IsDownBorderOut(position.y);
            var isLeftBorderOut = IsLeftBorderOut(position.x);
            var isRightBorderOut = IsRightBorderOut(position.x);
            return isDownBorderOut || isLeftBorderOut || isRightBorderOut;
        }

        public Vector3 GetDestructionPosition(Vector3 position)
        {
            var result = position;
            
            if (IsDownBorderOut(position.y))
            {
                result.y += DestructionOffset;
            }

            if (IsLeftBorderOut(position.x))
            {
                result.x += DestructionOffset;
            }
            else if (IsRightBorderOut(position.x))
            {
                result.x -= DestructionOffset;
            }

            return result;
        }

                
        private bool IsDownBorderOut(float y)
        {
            return y < Down;
        }
        
        private bool IsLeftBorderOut(float x)
        {
            return x < Left;
        }
        
        private bool IsRightBorderOut(float x)
        {
            return x > Right;
        }
    }
}