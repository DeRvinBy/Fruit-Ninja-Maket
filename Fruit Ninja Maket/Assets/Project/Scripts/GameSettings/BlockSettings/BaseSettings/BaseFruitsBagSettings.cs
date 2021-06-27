using Project.Scripts.Blocks;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.BaseSettings
{
    public class BaseFruitsBagSettings : BaseBlockSettings
    {
        [SerializeField] 
        private FruitsBag prefab = null;
        
        [SerializeField] 
        private int minCountOfFruits = 3;
        
        [SerializeField] 
        private int maxCountOfFruits = 5;

        [SerializeField] 
        private float minVelocityCoefficient = 0.2f;
        
        [SerializeField] 
        private float maxVelocityCoefficient = 0.5f;

        [SerializeField] 
        private float minDirectionAngle = 60f;
        
        [SerializeField] 
        private float maxDirectionAngle = 120f;

        public FruitsBag Prefab => prefab;
        public int CountOfFruits => Random.Range(minCountOfFruits, maxCountOfFruits);
        public float VelocityCoefficient => Random.Range(minVelocityCoefficient, maxVelocityCoefficient);
        public float DirectionAngle => Random.Range(minDirectionAngle, maxDirectionAngle);
    }
}