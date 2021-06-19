using Project.Scripts.Blocks;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.BaseSettings
{
    public class BaseHeartSettings : BaseBlockSettings
    {
        [Header("Heart settings")] 
        [SerializeField]
        private Heart prefab = null;

        [SerializeField] 
        private int countOfAddingLives = 1;

        public Heart Prefab => prefab;
        public int CountOfAddingLives => countOfAddingLives;
    }
}