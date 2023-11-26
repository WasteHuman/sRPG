using Assets.Scripts.Turret;

namespace Assets.Scripts.TurretSpawn
{
    public class TurretMarket
    {
        private TurretMarketAsset m_Asset;

        public TurretMarket(TurretMarketAsset asset)
        {
            m_Asset = asset;
        }

        public TurretAsset ChosenTurret => m_Asset.TurretAssets[0];
    }
}
