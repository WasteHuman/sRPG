using Assets.Scripts.Field;
using UnityEngine;
using Grid = Assets.Scripts.Field.Grid;

namespace Assets.Scripts.Enemy
{
    public class GridMovementAgent : IMovementAgent
    {
        private float m_Speed;
        private Transform m_Transform;

        public GridMovementAgent(float speed, Transform transform, Grid grid)
        {
            m_Speed = speed;
            m_Transform = transform;

            SetTargetNode(grid.GetStartNode());
        }

        private const float TOLERANCE = 0.1f;

        private Node m_TargetNode;

        public void TickMovement()
        {
            if (m_TargetNode == null)
            {
                return;
            }

            Vector3 target = m_TargetNode.Position;

            float distance = (target - m_Transform.position).magnitude;
            if (distance < TOLERANCE)
            {
                m_TargetNode = m_TargetNode.nextNode;
                return;
            }

            Vector3 direction = (target - m_Transform.position).normalized;
            Vector3 delta = direction * (m_Speed * Time.deltaTime);
            m_Transform.Translate(delta);
        }

        private void SetTargetNode(Node node)
        {
            m_TargetNode = node;
        }
    }
}
