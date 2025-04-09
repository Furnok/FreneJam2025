using UnityEngine;

public class S_DoorExit : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, S_TagName] private string tagPlayer;

    [Header("Input")]
    [SerializeField] private RSE_Interraction rseInterraction;

    [Header("Output")]
    [SerializeField] private RSO_Item rsoItem;
    [SerializeField] private RSE_MainMenu rseMainMenu;
    [SerializeField] private RSE_Game rseGame;
    [SerializeField] private RSE_UIInterract rseUIInterract;
    [SerializeField] private SSO_ItemNumber ssoItemNumber;
    [SerializeField] private RSE_Error rseError;

    private void OnDisable()
    {
        rseInterraction.action -= Interract;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            rseInterraction.action += Interract;
            rseUIInterract.Call(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            rseInterraction.action -= Interract;
            rseUIInterract.Call(false);
        }
    }

    private void Interract()
    {
        if (rsoItem.Value >= ssoItemNumber.Value)
        {
            rseGame.Call(false);
            rseMainMenu.Call(true);
        }
        else
        {
            rseError.Call();
        }
    }
}