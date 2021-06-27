using Project.Scripts.Blocks;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.BaseSettings
{
    public class BaseSnowflakeSettings : BaseBlockSettings
    {
        [Header("Snowflake settings")]
        [SerializeField] 
        private Snowflake prefab = null;

        [SerializeField] 
        private float slowdownEffectTime = 2f;
        
        public Snowflake Prefab => prefab;
        public float SlowdownEffectTime => slowdownEffectTime;
    }
}