using Project.Scripts.Blocks;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.BaseSettings
{
    public class BaseMagnetSettings : BaseBlockSettings
    {
        [Header("Magnet settings")]
        [SerializeField] 
        private Magnet prefab = null;

        [SerializeField] 
        private float magnetEffectTime = 5f;
        
        public Magnet Prefab => prefab;
        public float MagnetEffectTime => magnetEffectTime;
    }
}