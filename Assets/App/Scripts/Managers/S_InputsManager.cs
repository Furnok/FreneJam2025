using UnityEngine;
using UnityEngine.InputSystem;

public class S_InputsManager : MonoBehaviour
{
    [Header("Input")]
    
    [SerializeField] private RSE_Reset rseReset;

    [Header("Output")]
    [SerializeField] private RSE_Menu rseMenu;
    [SerializeField] private SSO_DelayInputs ssoDelayInputs;
    [SerializeField] private RSE_Move rseMove;
    [SerializeField] private RSE_Interraction rseInterraction;

    private void OnEnable()
    {
        rseReset.action += ResetScript;
    }

    private void OnDisable()
    {
        rseReset.action -= ResetScript;
    }

    private void ResetScript()
    {
        StopAllCoroutines();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 move = context.ReadValue<Vector2>();
            StartCoroutine(S_Utils.DelayRealtime(ssoDelayInputs.Value, () => rseMove.Call(move)));
        }
        else if (context.canceled)
        {
            StartCoroutine(S_Utils.DelayRealtime(ssoDelayInputs.Value, () => rseMove.Call(Vector2.zero)));
        }
    }

    public void Menu(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StartCoroutine(S_Utils.DelayRealtime(ssoDelayInputs.Value, () => rseMenu.Call()));
        }
    }

    public void Interraction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            StartCoroutine(S_Utils.DelayRealtime(ssoDelayInputs.Value, () => rseInterraction.Call()));
        }
    }
}