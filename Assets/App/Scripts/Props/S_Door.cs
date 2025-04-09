using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class S_Door : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float timeAnim;

    [Header("References")]
    [SerializeField] private Transform doorLeft;
    [SerializeField] private Transform doorRight;

    [Header("Input")]
    [SerializeField] private RSE_OpenDoor rseOpenDoor;
    [SerializeField] private RSE_Reset rseReset;

    private void OnEnable()
    {
        rseOpenDoor.action += HandleDoor;
        rseReset.action += ResetScript;
    }

    private void OnDisable()
    {
        rseOpenDoor.action -= HandleDoor;
        rseReset.action -= ResetScript;

        transform.DOKill();
    }

    private void ResetScript()
    {
        CloseDoor(0);
    }

    private void HandleDoor(bool value)
    {
        if (value)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor(timeAnim);
        }
    }

    private void DoMove(Transform transform, float value, float time)
    {
        transform.DOLocalMoveX(value, time).SetEase(Ease.Linear);
    }

    private void OpenDoor()
    {
        DoMove(doorLeft, -3, timeAnim);
        DoMove(doorRight, 3, timeAnim);
    }

    private void CloseDoor(float time)
    {
        DoMove(doorLeft, -1, timeAnim);
        DoMove(doorRight, 1, timeAnim);
    }
}