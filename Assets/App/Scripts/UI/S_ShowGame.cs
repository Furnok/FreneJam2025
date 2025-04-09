using System.Collections.Generic;
using UnityEngine;

public class S_ShowGame : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int startIndexLevel;

    [Header("Reference")]
    [SerializeField] private List<GameObject> contentGame;

    [Header("Input")]
    [SerializeField] private RSE_Game rseGame;
    [SerializeField] private RSO_Player rsoPlayer;
    [SerializeField] private RSO_Dead rsoDead;

    [Header("Output")]
    [SerializeField] private SSO_MainMenuMode ssoMainMenuMode;

    private int indexLevel = 0;

    private void Awake()
    {
        rsoPlayer.Value = new();
        rsoDead.Value = new();
        indexLevel = startIndexLevel;
    }

    private void OnEnable()
    {
        rseGame.action += HandleGame;
    }

    private void OnDisable()
    {
        rseGame.action -= HandleGame;
    }

    private void Start()
    {
        rseGame.Call(!ssoMainMenuMode.Value);
    }

    private void HandleGame(bool value)
    {
        contentGame[indexLevel].SetActive(value);
    }
}