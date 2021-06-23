using System;
using UnityEngine;

namespace Project.Scripts.GameSettings.SpawnSettings
{
    [Serializable]
    public class SpawnDifficultySettings
    {
        [SerializeField]
        private float decreasingValueOfNextZoneSpawnTime = 0.5f;

        [SerializeField] 
        private float minValueOfNextZoneSpawnTime = 0.5f;
        
        [SerializeField]
        private int increasingValueOfCountObjects = 1;

        [SerializeField] 
        private int maxValueOfCountObjects = 15;

        [SerializeField] 
        private int[] difficultyLevelsByScore;

        private int currentLevel = 0;

        public void MultiplyScoreOfLevels(int scoreMultiply)
        {
            for (int i = 0; i < difficultyLevelsByScore.Length; i++)
            {
                difficultyLevelsByScore[i] *= scoreMultiply;
            }
        }
        
        public void UpdateDifficulty(int score, ref float currentTime, ref int currentBaseCount)
        {
            while(!IsMaxLevel())
            {
                var levelScore = difficultyLevelsByScore[currentLevel];

                if (score < levelScore)
                {
                    return;
                }
                
                currentTime -= decreasingValueOfNextZoneSpawnTime;
                if (currentTime < minValueOfNextZoneSpawnTime)
                {
                    currentTime = minValueOfNextZoneSpawnTime;
                }
                
                currentBaseCount += increasingValueOfCountObjects;
                if (currentBaseCount > maxValueOfCountObjects)
                {
                    currentBaseCount = maxValueOfCountObjects;
                }

                currentLevel++;
            }
        }

        private bool IsMaxLevel()
        {
            return currentLevel >= difficultyLevelsByScore.Length;
        }
    }
}