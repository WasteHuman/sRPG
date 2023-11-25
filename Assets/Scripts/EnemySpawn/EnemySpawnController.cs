﻿using Assets.Scripts.Assets;
using Grid = Assets.Scripts.Field.Grid;
using Assets.Scripts.Runtime;
using UnityEngine;
using Assets.Scripts.Enemy;

namespace Assets.Scripts.EnemySpawn
{
    public class EnemySpawnController : IController
    {
        private SpawnWavesAsset m_SpawnWaves;
        private Grid m_Grid;

        private float m_SpawnStartTime;
        private float m_PassedTimeAtPreviousFrame = -1f;

        public EnemySpawnController(SpawnWavesAsset spawnWaves, Grid grid)
        {
            m_SpawnWaves = spawnWaves;
            m_Grid = grid;
        }

        public void OnStart()
        {
            m_SpawnStartTime = Time.time;
        }

        public void OnStop()
        {
            
        }

        public void Tick()
        {
            float passedTime = Time.time - m_SpawnStartTime;
            float timeToSpawn = 0f;

            foreach (SpawnWave wave in m_SpawnWaves.SpawnWaves)
            {
                timeToSpawn += wave.TimeBeforeStartWave;

                for (int i = 0; i < wave.Count; i++)
                {
                    if (passedTime >= timeToSpawn && m_PassedTimeAtPreviousFrame < timeToSpawn)
                    {
                        SpawnEnemy(wave.EnemyAsset);
                    }

                    if (i < wave.Count - 1)
                    {
                        timeToSpawn += wave.TimeBetweenSpawns;
                    }
                }
            }            

            m_PassedTimeAtPreviousFrame = passedTime;
        }

        private void SpawnEnemy(EnemyAsset asset)
        {
            EnemyView view = Object.Instantiate(asset.ViewPrefab);
            view.transform.position = m_Grid.GetStartNode().Position;
            EnemyData data = new EnemyData(asset);

            data.AttachView(view);
            view.CreateMovementAgent(m_Grid);

            Game.Player.EnemySpawned(data);
        }
    }
}