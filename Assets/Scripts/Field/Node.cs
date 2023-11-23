using UnityEngine;

namespace Assets.Scripts.Field
{
    public class Node
    {
        public Vector3 Position;

        public Node nextNode;
        public bool isOccupied;

        public float pathWeight;

        public Node(Vector3 position)
        {
            Position = position;
        }

        public void ResetWeight()
        {
            pathWeight = float.MaxValue;
        }
    }
}