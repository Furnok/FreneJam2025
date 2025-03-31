using UnityEngine;

public class S_UIMenuManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject contentUIParent;
    [SerializeField] private GameObject contentWorldParent;

    [Header("Input")]
    [SerializeField] private RSE_StartGame rseStartGame;
    [SerializeField] private RSE_QuitGame rseQuitGame;

    [Header("Output")]
    [SerializeField] private RSE_ResetCursor rseResetCursor;

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
        contentUIParent.SetActive(false);
        contentWorldParent.SetActive(true);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}