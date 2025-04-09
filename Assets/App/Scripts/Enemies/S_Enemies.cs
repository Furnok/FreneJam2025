using UnityEngine;

public class S_Enemies : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float viewRadius;
    [SerializeField, Range(0, 360)] private float viewAngle;
    [SerializeField] private LayerMask obstacleMask;

    [Header("Output")]
    [SerializeField] private RSO_Player rsoPlayer;

    private void Update()
    {
        if (CanSeePlayer())
        {
            Debug.Log("Player spotted!");
        }
    }

    public bool CanSeePlayer()
    {
        Vector3 directionToPlayer = (rsoPlayer.Value - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, rsoPlayer.Value);

        if (distanceToPlayer < viewRadius)
        {
            float angle = Vector3.Angle(transform.forward, directionToPlayer);
            if (angle < viewAngle / 2f)
            {
                if (!Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleMask))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle / 2, 0) * transform.forward;
        Vector3 rightBoundary = Quaternion.Euler(0, viewAngle / 2, 0) * transform.forward;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary * viewRadius);
    }
}