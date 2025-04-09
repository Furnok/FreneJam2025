using UnityEngine;

public class S_ShowGameOver : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject contentGameOver;

    [Header("Input")]
    [SerializeField] private RSE_Dead rseDead;

    [Header("Output")]
    [SerializeField] private RSE_ShowMouseCursor rseShowMouseCursor;

    private void OnEnable()
    {
        rseDead.action += HandleGameOver;
    }

    private void OnDisable()
    {
        rseDead.action -= HandleGameOver;
    }

    private void HandleGameOver(bool value)
    {
        if (value)
        {
            rseShowMouseCursor.Call();
            contentGameOver.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            contentGameOver.SetActive(false);
            Time.timeScale = 1;
        }
    }
}