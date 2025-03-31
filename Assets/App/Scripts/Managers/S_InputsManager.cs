using UnityEngine;
using UnityEngine.InputSystem;

public class S_InputsManager : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private RSE_Menu rseMenu;

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
            rseMenu.Call();
        }
    }
}