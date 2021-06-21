using System;
using UnityEngine;

namespace Project.Scripts.GameSettings.BlockSettings.AdditionalSettings
{
    [Serializable]
    public class ScoreFruitSettings
    {
        [SerializeField] 
        private int minScoreByTime = 10;
        
        [SerializeField] 
        private int maxScoreByTime = 30;

        [SerializeField] 
        private float minLifeTimeScore = 1f;
        
        [SerializeField] 
        private float maxLifeTimeScore = 3f;

        public int GetScoreByTime(float time)
        {
            var coef = time / (maxLifeTimeScore - minLifeTimeScore);
            var value = Mathf.Lerp(maxScoreByTime, minScoreByTime, coef);
            return Mathf.RoundToInt(value);
        }
    }
}