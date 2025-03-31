using UnityEngine;

public class S_ShowMainMenu : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject contentMainMenu;

    [Header("Input")]
    [SerializeField] private RSE_MainMenu rseMainMenu;

    [Header("Output")]
    [SerializeField] private SSO_MainMenuMode ssoMainMenuMode;

    private void OnEnable()
    {
        rseMainMenu.action += HandleMainMenu;
    }

    private void OnDisable()
    {
        rseMainMenu.action -= HandleMainMenu;
    }

    private void Start()
    {
        rseMainMenu.Call(ssoMainMenuMode.Value);
    }

    private void HandleMainMenu(bool value)
    {
        contentMainMenu.SetActive(value);
    }
}