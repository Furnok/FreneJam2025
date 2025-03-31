using UnityEngine;

public class S_ShowGame : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject contentGame;

    [Header("Input")]
    [SerializeField] private RSE_Game rseGame;

    [Header("Output")]
    [SerializeField] private SSO_MainMenuMode ssoMainMenuMode;

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
    }
}