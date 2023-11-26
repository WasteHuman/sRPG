using UnityEngine;

namespace Assets.Scripts.Turret
{
    public class TurretView : MonoBehaviour
    {
        [SerializeField]
        private Transform m_ProjectileOrigin;

        private TurretData m_Data;

        public TurretData TurretData => m_Data;

        public Transform ProjectileOrigin => m_ProjectileOrigin;

        public void AttachData(TurretData data)
        {
            m_Data = data;
            transform.position = m_Data.Node.Position;
        }
    }
}
