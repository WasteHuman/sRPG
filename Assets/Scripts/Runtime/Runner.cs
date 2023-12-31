﻿using Assets.Scripts.Enemy;
using Assets.Scripts.EnemySpawn;
using Assets.Scripts.Field;
using Assets.Scripts.TurretSpawn;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Runtime
{
    public class Runner : MonoBehaviour
    {
        private List<IController> m_Colntollers;
        private bool m_IsRunning = false;

        private void Update()
        {
            if (!m_IsRunning)
            {
                return;
            }

            TickControllers();
        }

        public void StartRunning()
        {
            CreateAllControllers();
            OnStartControllers();
            m_IsRunning = true;
        }

        public void StopRunning()
        {
            OnStopControllers();
            m_IsRunning = false;
        }

        private void CreateAllControllers()
        {
            m_Colntollers = new List<IController>
            {
                new GridRaycastController(Game.Player.GridHolder),
                new EnemySpawnController(Game.CurrentLevel.SpawnWavesAsset, Game.Player.Grid),
                new TurretSpawnController(Game.Player.Grid, Game.Player.TurretMarket),
                new MovementController()
            };
        }

        private void OnStartControllers()
        {
            foreach (IController controller in m_Colntollers)
            {
                try
                {
                    controller.OnStart();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
        private void TickControllers()
        {
            foreach (IController controller in m_Colntollers)
            {
                try
                {
                    controller.Tick();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
        private void OnStopControllers()
        {
            foreach (IController controller in m_Colntollers)
            {
                try
                {
                    controller.OnStop();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
    }
}