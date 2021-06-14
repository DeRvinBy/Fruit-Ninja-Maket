﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.GameSettings.SpawnSettings
{
    [Serializable]
    public class SpawnObjectsSettings
    {
        [SerializeField]
        [Range(0f, 180f)]
        private float minDirectionAngle = 60f;

        [SerializeField]
        [Range(0f, 180f)]
        private float maxDirectionAngle = 120f;

        [SerializeField]
        private int minSpawnObjectsCount = 1;

        [SerializeField]
        private int maxSpawnObjectsCount = 5;

        [SerializeField]
        private float baseVelocityOfObjects = 20f;

        public float DirectionAngle { get => Random.Range(minDirectionAngle, maxDirectionAngle); }
        public int SpawnObjectsCount { get => Random.Range(minSpawnObjectsCount, maxSpawnObjectsCount); }
        public float BaseVelocityOfObjects { get => baseVelocityOfObjects; }
    }
}