using UnityEngine;

public class S_ItemLevel : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, S_TagName] private string tagPlayer;

    [Header("References")]
    [SerializeField] private GameObject item;

    [Header("Input")]
    [SerializeField] private RSE_Interraction rseInterraction;
    [SerializeField] private RSO_Item rsoItem;
    [SerializeField] private RSE_Reset rseReset;

    private bool isTaken = false;

    private void OnEnable()
    {
        rseReset.action += ResetScript;
    }

    private void OnDisable()
    {
        rseInterraction.action -= Interract;
        rseReset.action -= ResetScript;
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

    private void ResetScript()
    {
        isTaken = false;
        item.SetActive(true);
    }

    private void Interract()
    {
        if (!rsoItem.Value && !isTaken)
        {
            isTaken = true;
            item.SetActive(false);
            rsoItem.Value = true;
        }
    }
}