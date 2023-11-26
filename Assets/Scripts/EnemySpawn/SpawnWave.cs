﻿using Assets.Scripts.Enemy;

namespace Assets.Scripts.EnemySpawn
{
    [System.Serializable]
    public class SpawnWave
    {
        public EnemyAsset EnemyAsset;
        public int Count;
        public float TimeBetweenSpawns;

        public float TimeBeforeStartWave;
    }
}