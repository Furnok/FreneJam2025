using UnityEngine;

public class S_ShowGame : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject contentGame;
    [SerializeField] private GameObject player;

    [Header("Input")]
    [SerializeField] private RSE_Game rseGame;
    [SerializeField] private RSO_Player rsoPlayer;

    [Header("Output")]
    [SerializeField] private SSO_MainMenuMode ssoMainMenuMode;

    private void Awake()
    {
        rsoPlayer.Value = new();
    }

    private void OnEnable()
    {
        rseGame.action += HandleGame;
    }

    private void OnDisable()
    {
        rseGame.action -= HandleGame;
    }

    private void Start()
    {
        rseGame.Call(!ssoMainMenuMode.Value);
    }

    private void HandleGame(bool value)
    {
        contentGame.SetActive(value);
        rsoPlayer.Value = player.transform.position;
    }
}