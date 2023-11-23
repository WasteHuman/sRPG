using Assets.Scripts.Field;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class GridMovementAgent : MonoBehaviour
    {
        [SerializeField]
        private float m_Speed;

        private const float TOLERANCE = 0.1f;

        private Node m_TargetNode;

        private void Update()
        {
            if (m_TargetNode == null)
            {
                return;
            }

            Vector3 target = m_TargetNode.Position;

            float distance = (target - transform.position).magnitude;
            if (distance < TOLERANCE)
            {
                m_TargetNode = m_TargetNode.nextNode;
                return;
            }

            Vector3 direction = (target - transform.position).normalized;
            Vector3 delta = direction * (m_Speed * Time.deltaTime);
            transform.Translate(delta);
        }

        public void SetStartNode(Node node)
        {
            m_TargetNode = node;
        }
    }
}
