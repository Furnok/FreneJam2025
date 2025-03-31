using UnityEngine;

public class S_ShownMenu : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject contentMenu;

    [Header("Input")]
    [SerializeField] private RSE_Game rseGame;
    [SerializeField] private RSE_Menu rseMenu;

    [Header("Output")]
    [SerializeField] private RSE_ResetCursor rseResetCursor;

    private bool isInGame;

    private void OnEnable()
    {
        rseGame.action += HandleMenu;
        rseMenu.action += Menu;
    }

    private void OnDisable()
    {
        rseGame.action -= HandleMenu;
        rseMenu.action -= Menu;
    }

    private void HandleMenu(bool value)
    {
        isInGame = value;
    }

    private void Menu()
    {
        if (!contentMenu.activeInHierarchy && isInGame)
        {
            Time.timeScale = 0;
            contentMenu.SetActive(true);
        }
        else
        {
            rseResetCursor.Call();
            Time.timeScale = 1;
            contentMenu.SetActive(false);
        }
    }
}