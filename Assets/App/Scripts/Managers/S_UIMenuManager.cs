using UnityEngine;

public class S_UIMenuManager : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private RSE_ResumeGame rseResumeGame;

    [Header("Output")]
    [SerializeField] private RSE_ResetCursor rseResetCursor;
    [SerializeField] private RSE_Menu rseMenu;
    [SerializeField] private RSE_Game rseGame;

    private void OnEnable()
    {
        rseResumeGame.action += ResumeGame;
    }

    private void OnDisable()
    {
        rseResumeGame.action -= ResumeGame;
    }

    private void ResumeGame()
    {
        rseResetCursor.Call();
        rseMenu.Call();
        rseGame.Call(true);
    }
}