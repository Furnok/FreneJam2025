using System.Collections;
using UnityEngine;

public class S_PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;

    [Header("References")]
    [SerializeField] private Rigidbody rb;

    [Header("Input")]
    [SerializeField] private RSE_Move rseMove;
    [SerializeField] private RSO_Player rsoPlayer;

    private Vector3 currentMove;

    private void OnEnable()
    {
        rseMove.action += Move;
    }

    private void OnDisable()
    {
        rseMove.action -= Move;
    }

    private void Update()
    {
        rb.linearVelocity = new Vector3(currentMove.x * speed, transform.position.y, currentMove.y * speed);

        rsoPlayer.Value = transform.position;
    }

    private void Move(Vector2 move)
    {
        if (move.x == 0 && move.y == 0)
        {
            currentMove = Vector3.zero;
        }
        else
        {
            currentMove = move;
        }
    }
}