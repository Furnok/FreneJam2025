using UnityEngine;

public class S_ShowMenu : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject contentMenu;

    [Header("Input")]
    [SerializeField] private RSE_Menu rseMenu;

    private void OnEnable()
    {
        rseMenu.action += HandleMenu;
    }

    private void OnDisable()
    {
        rseMenu.action -= HandleMenu;
    }

    private void HandleMenu(bool value)
    {
        contentMenu.SetActive(value);
    }
}