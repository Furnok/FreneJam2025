using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class S_PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;

    [Header("References")]
    [SerializeField] private Rigidbody rb;

    [Header("Input")]
    [SerializeField] private RSE_Move rseMove;
    [SerializeField] private RSO_Player rsoPlayer;
    [SerializeField] private RSE_SpawnPoint rseSpawnPoint;
    [SerializeField] private RSE_Reset rseReset;

    private Vector3 currentMove = Vector3.zero;
    private bool isSpawn = false;

    private void OnEnable()
    {
        rseMove.action += Move;
        rseSpawnPoint.action += Spawn;
        rseReset.action += RestScript;
    }

    private void OnDisable()
    {
        rseMove.action -= Move;
        rseSpawnPoint.action -= Spawn;
        rseReset.action -= RestScript;
    }

    private void Update()
    {
        if (isSpawn)
        {
            rb.linearVelocity = new Vector3(currentMove.x * speed, transform.position.y, currentMove.y * speed);

            rsoPlayer.Value = transform.position;
        }
    }

    private void RestScript()
    {
        rb.linearVelocity = Vector3.zero;
        transform.position = new Vector3(0, 1.5f, 0);
        rsoPlayer.Value = transform.position;
        isSpawn = false;
    }

    private void Spawn(Vector3 pos)
    {
        rb.linearVelocity = Vector3.zero;
        transform.position = pos;
        rsoPlayer.Value = transform.position;
        isSpawn = true;
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