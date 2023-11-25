using UnityEngine;

namespace Assets.Scripts.Field
{
    public class GridHolder : MonoBehaviour
    {
        [SerializeField]
        private int m_GridWidth;
        [SerializeField]
        private int m_GridHeight;

        [SerializeField]
        private Vector2Int m_TargetCoordinate;
        [SerializeField]
        private Vector2Int m_StartCoordinate;

        [SerializeField]
        private float m_NodeSize;

        private Grid m_Grid;

        private Camera m_Camera;

        private Vector3 m_Offset;

        public Vector2Int StartCoordinate => m_StartCoordinate;

        public Grid Grid => m_Grid;

        public void CreateGrid()
        {
            m_Camera = Camera.main;

            float width = m_GridWidth * m_NodeSize;
            float height = m_GridHeight * m_NodeSize;

            // Default plane space is 10 by 10
            transform.localScale = new Vector3(
                width * 0.1f,
                1f,
                height * 0.1f);

            m_Offset = transform.position -
                (new Vector3(width, 0f, height) * 0.5f);

            m_Grid = new Grid(m_GridWidth, m_GridHeight, m_Offset, m_NodeSize, m_StartCoordinate, m_TargetCoordinate);
        }

        private void OnValidate()
        {
            float width = m_GridWidth * m_NodeSize;
            float height = m_GridHeight * m_NodeSize;

            // Default plane space is 10 by 10
            transform.localScale = new Vector3(
                width * 0.1f,
                1f,
                height * 0.1f);

            m_Offset = transform.position -
                (new Vector3(width, 0f, height) * 0.5f);
        }

        public void RaycastInGrid()
        {
            if (m_Grid == null || m_Camera == null)
            {
                return;
            }

            Vector3 mousePosition = Input.mousePosition;

            Ray ray = m_Camera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform != transform)
                {
                    m_Grid.UnselectedNode();
                    return;
                }

                Vector3 hitPosition = hit.point;
                Vector3 difference = hitPosition - m_Offset;

                int x = (int) (difference.x / m_NodeSize);
                int z = (int) (difference.z / m_NodeSize);

                m_Grid.SelectCoordinate(new Vector2Int(x, z));
            }
            else
            {
                m_Grid.UnselectedNode();
            }
        }

        private void OnDrawGizmos()
        {
            if (m_Grid == null)
            {
                return;
            }

            Gizmos.color = Color.red;

            foreach (Node node in m_Grid.EnumerateAllNodes())
            {
                if (node.nextNode == null)
                {
                    continue;
                }
                if (node.isOccupied)
                {
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawSphere(node.Position, 0.5f);
                    continue;
                }
                Gizmos.color = Color.red;
                Vector3 start = node.Position;
                Vector3 end = node.nextNode.Position;

                Vector3 direction = end - start;

                start -= direction * 0.25f;
                end -= direction * 0.75f;

                Gizmos.DrawLine(start, end);
                Gizmos.DrawSphere(end, 0.1f);
            }
        }
    }
}