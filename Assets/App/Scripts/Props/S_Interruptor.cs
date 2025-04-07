using UnityEngine;

public class S_Interruptor : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, S_TagName] private string tagPlayer;

    [Header("Input")]
    [SerializeField] private RSE_Interraction rseInterraction;

    [Header("Output")]
    [SerializeField] private RSE_OpenDoor rseOpenDoor;

    private bool isActive = false;

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
        if (!isActive)
        {
            isActive = true;
            rseOpenDoor.Call(true);
        }
        else
        {
            isActive = false;
            rseOpenDoor.Call(false);
        }
    }
}