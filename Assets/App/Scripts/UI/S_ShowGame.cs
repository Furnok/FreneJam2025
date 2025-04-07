using System.Collections.Generic;
using UnityEngine;

public class S_ShowGame : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int startIndexLevel;

    [Header("Reference")]
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> contentGame;

    [Header("Input")]
    [SerializeField] private RSE_Game rseGame;
    [SerializeField] private RSO_Player rsoPlayer;

    [Header("Output")]
    [SerializeField] private SSO_MainMenuMode ssoMainMenuMode;

    private int indexLevel = 0;

    private void Awake()
    {
        rsoPlayer.Value = new();
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

        if (value)
        {
            player.SetActive(true);
        }
        else
        {
            player.SetActive(false);
        }
    }
}