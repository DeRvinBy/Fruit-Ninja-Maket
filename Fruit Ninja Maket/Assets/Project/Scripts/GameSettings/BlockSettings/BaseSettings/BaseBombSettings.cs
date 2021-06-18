using Project.Scripts.Blocks;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.BaseSettings
{
    public class BaseBombSettings : BaseBlockSettings
    {
        [Header("Bomb settings")]
        [SerializeField] 
        private Bomb prefab = null;
        
        [SerializeField] 
        private float explosionRadius = 1f;

        [SerializeField] 
        private float explosionForce = 5f;

        public Bomb Prefab => prefab;
        public float ExplosionRadius => explosionRadius;
        public float ExplosionForce => explosionForce;
    }
}