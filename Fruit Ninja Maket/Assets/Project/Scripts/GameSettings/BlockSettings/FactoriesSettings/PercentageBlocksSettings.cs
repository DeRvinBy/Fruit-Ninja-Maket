using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.FactoriesSettings
{
    public class PercentageBlocksSettings : MonoBehaviour
    {
        [SerializeField] 
        [Range(0f, 1f)] 
        private float percentOfBlocksInBundle = 0.5f;
        
        public float PercentOfBlocksInBundle => percentOfBlocksInBundle;
    }
}