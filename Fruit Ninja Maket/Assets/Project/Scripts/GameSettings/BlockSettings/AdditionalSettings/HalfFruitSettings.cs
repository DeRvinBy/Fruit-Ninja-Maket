using System;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.AdditionalSettings
{
    [Serializable]
    public class HalfFruitSettings
    {
        [SerializeField]
        private float halfVelocity = 4f;
        
        [SerializeField]
        private float halfMass = 20f;


        public float HalfVelocity => halfVelocity;

        public float HalfMass => halfMass;
    }
}