using Assets.Scripts.Enemy;
using Assets.Scripts.Field;
using Assets.Scripts.Turret.Weapon;
using Assets.Scripts.TurretSpawn;
using System.Collections.Generic;
using UnityEngine;
using Grid = Assets.Scripts.Field.Grid;

namespace Assets.Scripts.Runtime
{
    public class Player
    {
        private List<EnemyData> m_EnemyDatas = new List<EnemyData>();
        public IReadOnlyList<EnemyData> EnemyDatas => m_EnemyDatas;

        public readonly GridHolder GridHolder;
        public readonly Grid Grid;
        public readonly TurretMarket TurretMarket;
        public readonly EnemySearch EnemySearch;

        public Player()
        {
            GridHolder = Object.FindObjectOfType<GridHolder>();
            GridHolder.CreateGrid();
            Grid = GridHolder.Grid;

            TurretMarket = new TurretMarket(Game.CurrentLevel.TurretMarketAsset);

            EnemySearch = new EnemySearch(m_EnemyDatas);
        }

        public void EnemySpawned(EnemyData data)
        {
            m_EnemyDatas.Add(data);
        }
    }
}
