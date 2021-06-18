using System;
using System.Linq;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Project.Scripts.Extensions
{
    public static class RandomItemInList
    {
        public static T GetRandomItemByProbability<T>(this IEnumerable<T> list, Func<T, float> item)
        {
            var sum = list.Sum(item);
            
            var randomPoint = Random.value * sum;

            foreach (var arg in list)
            {
                var prob = item(arg);
                if (randomPoint < prob)
                {
                    return arg;
                }
                else
                {
                    randomPoint -= prob;
                }
            }

            return list.Last();
        }
    }
}