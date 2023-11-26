using Assets.Scripts.Field;

namespace Assets.Scripts.Turret
{
    public class TurretData
    {
        private TurretView m_View;
        private Node m_node;

        public TurretView TurretView => m_View;
        public Node Node => m_node;

        public TurretData(TurretAsset asset, Node node)
        {
            m_node = node;
        }

        public void AttachView(TurretView view)
        {
            m_View = view;
            m_View.AttachData(this);
        }
    }
}
