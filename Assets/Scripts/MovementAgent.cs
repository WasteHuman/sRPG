using UnityEngine;
public class MovementAgent : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_TargetPosition;

    [SerializeField]
    private float m_Speed;

    private const float TOLERANCE = 0.1f;


    private void Update()
    {
        float distance = (m_TargetPosition - transform.position).magnitude;
        if (distance < TOLERANCE)
        {
            return;
        }

        Vector3 direction = (m_TargetPosition - transform.position).normalized;
        Vector3 delta = direction * (m_Speed * Time.deltaTime);
        transform.Translate(delta);
    }
}
