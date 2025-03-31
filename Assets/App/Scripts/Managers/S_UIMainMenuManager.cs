using UnityEngine;

public class S_UIMainMenuManager : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private RSE_StartGame rseStartGame;

    [Header("Output")]
    [SerializeField] private RSE_ResetCursor rseResetCursor;
    [SerializeField] private RSE_MainMenu rseMainMenu;
    [SerializeField] private RSE_Game rseGame;

    private void OnEnable()
    {
        rseStartGame.action += StartGame;
    }

    private void OnDisable()
    {
        rseStartGame.action -= StartGame;
    }

    private void StartGame()
    {
        rseResetCursor.Call();
        rseMainMenu.Call(false);
        rseGame.Call(true);
    }
}