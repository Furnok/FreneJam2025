using UnityEngine;

public class S_UIMainMenuManager : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private RSE_StartGame rseStartGame;

    [Header("Output")]
    [SerializeField] private RSE_ResetCursor rseResetCursor;
    [SerializeField] private RSE_MainMenu rseMainMenu;
    [SerializeField] private RSE_Game rseGame;
    [SerializeField] private RSE_ShowMouseCursor rseShowMouseCursor;

    private void OnEnable()
    {
        rseStartGame.action += StartGame;

        rseShowMouseCursor.Call();
    }

    private void OnDisable()
    {
        rseStartGame.action -= StartGame;
    }

    private void StartGame()
    {
        rseResetCursor.Call();
        rseGame.Call(true);
        rseMainMenu.Call(false);
    }
}