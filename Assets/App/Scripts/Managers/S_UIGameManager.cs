using UnityEngine;

public class S_UIGameManager : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private RSO_Item rsoItem;

    [Header("Output")]
    [SerializeField] private RSE_HideMouseCursor rseHideMouseCursor;

    private void OnEnable()
    {
        rseHideMouseCursor.Call();
        rsoItem.Value = false;
    }
}