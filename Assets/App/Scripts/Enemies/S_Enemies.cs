using UnityEngine;

public class S_Enemies : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float viewRadius;
    [SerializeField, Range(0, 360)] private float viewAngle;
    [SerializeField] private LayerMask obstacleMask;
    [SerializeField, S_TagName] private string tagPlayer;

    [Header("Input")]
    [SerializeField] private RSE_Reset rseReset;

    [Header("Output")]
    [SerializeField] private RSO_Player rsoPlayer;

    private bool isPlayerInRadius = false;

    private void OnEnable()
    {
        rseReset.action += ResetScript;
    }

    private void OnDisable()
    {
        rseReset.action -= ResetScript;
    }

    private void Update()
    {
        if (isPlayerInRadius)
        {
            if (CanSeePlayer())
            {
                Debug.Log("Player spotted!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            isPlayerInRadius = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            isPlayerInRadius = false;
        }
    }

    private void ResetScript()
    {
        isPlayerInRadius = false;
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