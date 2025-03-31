using UnityEngine;

public class S_UIMenuManager : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private RSE_StartGame rseStartGame;
    [SerializeField] private RSE_QuitGame rseQuitGame;

    [Header("Output")]
    [SerializeField] private RSE_ResetCursor rseResetCursor;
    [SerializeField] private RSE_Menu rseMenu;
    [SerializeField] private RSE_Game rseGame;

    private void OnEnable()
    {
        rseStartGame.action += StartGame;
        rseQuitGame.action += QuitGame;
    }

    private void OnDisable()
    {
        rseStartGame.action -= StartGame;
        rseQuitGame.action -= QuitGame;
    }

    private void StartGame()
    {
        rseResetCursor.Call();
        rseMenu.Call(false);
        rseGame.Call(true);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}