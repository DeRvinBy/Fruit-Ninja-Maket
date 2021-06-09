using System;
using UnityEngine;

namespace Scripts.GameEntities.Containers
{   
    [Serializable]
    public class FruitHalfsSprites
    {
        [SerializeField]
        private Sprite left = null;

        [SerializeField]
        private Sprite right = null;

        public Sprite Left { get => left; }

        public Sprite Right { get => right; }
        
    }
}