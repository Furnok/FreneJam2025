using UnityEngine;

public class S_UIGameManager : MonoBehaviour
{
    [Header("Output")]
    [SerializeField] private RSE_HideMouseCursor rseHideMouseCursor;

    private void OnEnable()
    {
        rseHideMouseCursor.Call();
    }
}