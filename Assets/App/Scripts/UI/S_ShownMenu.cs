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
    [SerializeField] private RSE_ShowMouseCursor rseShowMouseCursor;
    [SerializeField] private RSE_HideMouseCursor rseHideMouseCursor;
    [SerializeField] private RSO_Dead rsoDead;

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
        if (!rsoDead.Value)
        {
            if (!contentMenu.activeInHierarchy && isInGame)
            {
                rseShowMouseCursor.Call();
                contentMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                rseResetCursor.Call();
                rseHideMouseCursor.Call();
                Time.timeScale = 1;
                contentMenu.SetActive(false);
            }
        }
    }
}