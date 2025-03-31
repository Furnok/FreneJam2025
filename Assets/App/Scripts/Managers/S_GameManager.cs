using UnityEngine;

public class S_GameManager : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private RSE_BackToMainMenu rseBackToMainMenu;
    [SerializeField] private RSE_QuitGame rseQuitGame;

    [Header("Output")]
    [SerializeField] private RSE_ResetCursor rseResetCursor;
    [SerializeField] private RSE_MainMenu rseMainMenu;
    [SerializeField] private RSE_Menu rseMenu;
    [SerializeField] private RSE_Game rseGame;

    private void OnEnable()
    {
        rseBackToMainMenu.action += MainMenu;
        rseQuitGame.action += QuitGame;
    }

    private void OnDisable()
    {
        rseBackToMainMenu.action -= MainMenu;
        rseQuitGame.action -= QuitGame;
    }

    private void MainMenu()
    {
        rseResetCursor.Call();
        rseGame.Call(false);
        rseMenu.Call();
        rseMainMenu.Call(true);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}