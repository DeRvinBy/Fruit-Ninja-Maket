using System.Collections;
using Project.Scripts.BlockFactory;
using Project.Scripts.GameSettings.BlockSettings.BaseSettings;
using UnityEngine;

namespace Project.Scripts.Blocks
{
    public class FruitsBag : SliceBlock
    {
        private const float DelayToSpawn = 0.1f;
        
        [SerializeField] 
        private GameObject spriteObject = null;

        private BaseFruitsBagSettings fruitsBagSettings;
        private FruitFactory fruitFactory;
        private bool isSpawnFruits;

        public void InitializeSettings(BaseFruitsBagSettings fruitsBagSettings, FruitFactory fruitFactory)
        {
            this.fruitsBagSettings = fruitsBagSettings;
            this.fruitFactory = fruitFactory;
        }

        public override void Slice(Vector2 slicingDirection)
        {
            if (isSliced) return;
            
            base.Slice(slicingDirection);

            StartCoroutine(SpawnFruits());
        }

        private IEnumerator SpawnFruits()
        {
            isSpawnFruits = true;
            yield return new WaitForSeconds(DelayToSpawn);
            var count = fruitsBagSettings.CountOfFruits;
            for (int i = 0; i < count; i++)
            {
                var direction = GetMovementDirection();
                direction *= fruitsBagSettings.VelocityCoefficient;
                fruitFactory.SpawnBlock(transform.position, direction);
            }

            isSpawnFruits = false;
        }

        private Vector2 GetMovementDirection()
        {
            var angle = fruitsBagSettings.DirectionAngle;
            return (Quaternion.Euler(0, 0, angle) * Vector2.right);
        }

        protected override void DisableBlockComponent()
        {
            base.DisableBlockComponent();
            spriteObject.SetActive(false);;
        }
        
        protected override bool IsCanDestroy()
        {
            var isOutOfBorder = destructionBoundaries.IsOutOfBorder(transform.position);
            return (isOutOfBorder || isSliced) && !isSpawnFruits;
        }
    }
}