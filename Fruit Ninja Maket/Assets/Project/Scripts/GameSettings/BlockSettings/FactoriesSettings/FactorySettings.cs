using System;
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
        private SliceBlockFactory blockFactory = null;

        public float SpawnProbability => spawnProbability;
        public SliceBlockFactory BlockFactory => blockFactory;
    }
}