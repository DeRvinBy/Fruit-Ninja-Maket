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
        [Range(0.1f, 1f)] 
        private float slowdownVelocityCoefficient = 0.2f;
        
        [SerializeField] 
        private float freezeTime = 2f;
        
        public Snowflake Prefab => prefab;
        public float FreezeTime => freezeTime;
        public float SlowdownVelocityCoefficient => slowdownVelocityCoefficient;
    }
}