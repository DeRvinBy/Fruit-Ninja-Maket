using System;
using Project.Scripts.BlockFactory;
using Project.Scripts.BlockFactory.Abstract;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.FactoriesSettings
{
    [Serializable]
    public class FactorySettings
    {
        [SerializeField] 
        private float spawnProbability = 1f;

        [SerializeField] 
        private BlockFactory.Abstract.BlockFactory blockFactory = null;

        public float SpawnProbability => spawnProbability;
        public BlockFactory.Abstract.BlockFactory BlockFactory => blockFactory;
    }
}