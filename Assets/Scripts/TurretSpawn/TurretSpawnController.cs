using Assets.Scripts.Field;
using Assets.Scripts.Runtime;
using Assets.Scripts.Turret;
using UnityEngine;
using Grid = Assets.Scripts.Field.Grid;

namespace Assets.Scripts.TurretSpawn
{
    public class TurretSpawnController : IController
    {
        private Grid m_Grid;
        private TurretMarket m_TurretMarket;

        public TurretSpawnController(Grid grid, TurretMarket turretMarket)
        {
            m_Grid = grid;
            m_TurretMarket = turretMarket;
        }

        public void OnStart()
        {

        }

        public void OnStop()
        {

        }

        public void Tick()
        {
            if (m_Grid.HasSelectedNode() && Input.GetMouseButtonDown(0))
            {
                Node selectedNode = m_Grid.GetSelectedNode();

                if (selectedNode.isOccupied)
                {
                    return;
                }

                SpawnTurret(m_TurretMarket.ChosenTurret, selectedNode);
            }
        }

        private void SpawnTurret(TurretAsset asset, Node node)
        {
            TurretView view = Object.Instantiate(asset.ViewPrefab);
            TurretData data = new TurretData(asset, node);

            data.AttachView(view);

            node.isOccupied = true;
            m_Grid.UpdatePathFinding();
        }
    }
}
