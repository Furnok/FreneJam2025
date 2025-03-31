using UnityEngine;
using UnityEngine.InputSystem;

public class S_InputsManager : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private RSE_Menu rseMenu;

    [Header("Output")]
    [SerializeField] private SSO_DelayInputs ssoDelayInputs;

    private Coroutine coroutineMenu;

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

        }
        else if (context.canceled)
        {

        }
    }

    public void Menu(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (coroutineMenu != null)
            {
                StopCoroutine(coroutineMenu);
                coroutineMenu = null;
            }

            coroutineMenu = StartCoroutine(S_Utils.DelayRealtime(ssoDelayInputs.Value, () => rseMenu.Call()));
        }
    }
}