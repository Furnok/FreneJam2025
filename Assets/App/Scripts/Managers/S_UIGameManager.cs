using TMPro;
using UnityEngine;

public class S_UIGameManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float timeError;

    [Header("References")]
    [SerializeField] private GameObject panelInterract;
    [SerializeField] private TextMeshProUGUI textItem;
    [SerializeField] private GameObject panelError;

    [Header("Input")]
    [SerializeField] private RSO_Item rsoItem;
    [SerializeField] private RSE_UIInterract rseUIInterract;
    [SerializeField] private RSE_TakeItem rseTakeItem;
    [SerializeField] private RSE_Error rseError;

    [Header("Output")]
    [SerializeField] private RSE_HideMouseCursor rseHideMouseCursor;
    [SerializeField] private SSO_ItemNumber ssoItemNumber;

    private Coroutine errorCoroutine;

    private void OnEnable()
    {
        rseUIInterract.action += HandleUIInterract;
        rseTakeItem.action += UpdateUI;
        rseError.action += ShowError;

        rseHideMouseCursor.Call();
        rsoItem.Value = 0;

        UpdateUI();
    }

    private void OnDisable()
    {
        rseUIInterract.action -= HandleUIInterract;
        rseTakeItem.action -= UpdateUI;
        rseError.action -= ShowError;
    }

    private void UpdateUI()
    {
        textItem.text = $"{rsoItem.Value}/{ssoItemNumber.Value} Item";
    }

    private void HandleUIInterract(bool value)
    {
        panelInterract.SetActive(value);
    }

    private void ShowError()
    {
        float time = 0;

        if (errorCoroutine != null)
        {
            panelError.SetActive(false);
            StopCoroutine(errorCoroutine);
            errorCoroutine = null;
            time = 0.1f;
        }

        StartCoroutine(S_Utils.Delay(time, () =>
        {
            panelError.SetActive(true);

            errorCoroutine = StartCoroutine(S_Utils.Delay(timeError, () =>
            {
                panelError.SetActive(false);
                errorCoroutine = null;
            }));
        }));
    }
}