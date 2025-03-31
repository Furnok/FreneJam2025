using UnityEngine;

public class S_ShowGame : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject contentGame;

    [Header("Input")]
    [SerializeField] private RSE_Game rseGame;

    private void OnEnable()
    {
        rseGame.action += HandleGame;
    }

    private void OnDisable()
    {
        rseGame.action -= HandleGame;
    }

    private void HandleGame(bool value)
    {
        contentGame.SetActive(value);
    }
}