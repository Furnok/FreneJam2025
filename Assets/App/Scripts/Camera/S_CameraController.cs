using UnityEngine;

public class S_CameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;

    [Header("Input")]
    [SerializeField] private RSE_Game rseGame;
    [SerializeField] private RSE_Reset rseReset;

    [Header("Output")]
    [SerializeField] private RSO_Player rsoPlayer;

    private bool isInGame = false;

    private void OnEnable()
    {
        rseGame.action += SetGameMode;
        rseReset.action += ResetScript;
    }

    private void OnDisable()
    {
        rseGame.action -= SetGameMode;
        rseReset.action -= ResetScript;
    }

    private void LateUpdate()
    {
        if (isInGame)
        {
            Vector3 targetPosition = new Vector3(rsoPlayer.Value.x, transform.position.y, rsoPlayer.Value.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    private void ResetScript()
    {
        transform.position = new Vector3(rsoPlayer.Value.x, transform.position.y, rsoPlayer.Value.z);
        isInGame = false;
    }

    private void SetGameMode(bool value)
    {
        isInGame = value;
    }
}