using System;
using Project.Scripts.BlockFactory;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.FactoriesSettings
{
    [Serializable]
    public class FactorySettings
    {
        [SerializeField] 
        private float spawnProbability = 1f;

        [SerializeField] 
        [Range(0f, 1f)]
        private float percentBlocksInBundle = 0.5f;
        
        [SerializeField] 
        private SliceBlockFactory blockFactory = null;

        private float countInBundle;
        private int maxCountInBundle;
        
        public float SpawnProbability => spawnProbability;
        public SliceBlockFactory BlockFactory => blockFactory;

        public void SetCountInBundle(int maxCountInBundle)
        {
            countInBundle = 0;
            this.maxCountInBundle = maxCountInBundle;
        }
        
        public SliceBlockFactory GetBlockFactoryByCountInBundle()
        {
            var percent = countInBundle / maxCountInBundle;
            if (percent < percentBlocksInBundle)
            {
                countInBundle++;
                return blockFactory;
            }
            else
            {
                return null;
            }
        }
    }
}