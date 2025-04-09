using UnityEngine;

public class S_ShowGameUI : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject contentGameUI;

    [Header("Input")]
    [SerializeField] private RSE_Game rseGame;

    private void OnEnable()
    {
        rseGame.action += HandleGameUI;
    }

    private void OnDisable()
    {
        rseGame.action -= HandleGameUI;
    }

    private void HandleGameUI(bool value)
    {
        contentGameUI.SetActive(value);
    }
}