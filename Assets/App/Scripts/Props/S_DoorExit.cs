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

    private void OnDisable()
    {
        rseInterraction.action -= Interract;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            rseInterraction.action += Interract;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagPlayer))
        {
            rseInterraction.action -= Interract;
        }
    }

    private void Interract()
    {
        if (rsoItem.Value)
        {
            rseGame.Call(false);
            rseMainMenu.Call(true);
        }
        else
        {
            Debug.Log("You don't have the Item");
        }
    }
}