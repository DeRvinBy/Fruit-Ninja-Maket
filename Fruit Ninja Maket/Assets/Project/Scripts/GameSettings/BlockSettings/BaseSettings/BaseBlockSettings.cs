using System;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.BaseSettings
{
    [Serializable]
    public class BaseBlockSettings : MonoBehaviour
    {
        [SerializeField]
        private float velocityOfObjects = 20f;
        
        public float VelocityOfObjects => velocityOfObjects;
    }
}