using UnityEngine;

public class S_ItemLevel : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, S_TagName] private string tagPlayer;

    [Header("Input")]
    [SerializeField] private RSE_Interraction rseInterraction;
    [SerializeField] private RSO_Item rsoItem;

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
        if (!rsoItem.Value)
        {
            rsoItem.Value = true;
        }
    }
}