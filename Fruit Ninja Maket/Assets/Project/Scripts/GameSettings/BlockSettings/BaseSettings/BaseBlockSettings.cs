using System;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.BaseSettings
{
    [Serializable]
    public class BaseBlockSettings : MonoBehaviour
    {
        [Header("Base settings")]
        [SerializeField]
        protected float velocityOfBlock = 20f;
        
        [SerializeField]
        protected float massOfBlock = 20f;
        
        [SerializeField] 
        protected int countOfReducingLives = 1;
        
        public float VelocityOfBlock => velocityOfBlock;
        public float MassOfBlock => massOfBlock;
        public int CountOfReducingLives => countOfReducingLives;
    }
}