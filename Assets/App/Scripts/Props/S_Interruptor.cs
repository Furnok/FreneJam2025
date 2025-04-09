using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class S_Interruptor : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, S_TagName] private string tagPlayer;
    [SerializeField] private float timeAnim;

    [Header("References")]
    [SerializeField] private Transform button;

    [Header("Input")]
    [SerializeField] private RSE_Interraction rseInterraction;
    [SerializeField] private RSE_Reset rseReset;

    [Header("Output")]
    [SerializeField] private RSE_OpenDoor rseOpenDoor;
    [SerializeField] private RSE_UIInterract rseUIInterract;

    private bool isActive = false;

    private void OnEnable()
    {
        rseReset.action += ResetScript;
    }

    private void OnDisable()
    {
        rseInterraction.action -= Interract;
        rseReset.action -= ResetScript;

        button.DOKill();
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

    private void ResetScript()
    {
        DoMove(button, 0.6f, 0);
    }

    private void DoMove(Transform transform, float value, float time)
    {
        transform.DOLocalMoveY(value, time).SetEase(Ease.Linear);
    }

    private void Interract()
    {
        if (!isActive)
        {
            isActive = true;

            DoMove(button, 0.4f, timeAnim);

            rseOpenDoor.Call(true);
        }
        else
        {
            isActive = false;

            DoMove(button, 0.6f, timeAnim);

            rseOpenDoor.Call(false);
        }
    }
}