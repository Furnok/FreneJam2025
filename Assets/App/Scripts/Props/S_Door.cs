using UnityEngine;
using DG.Tweening;

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

    private void OpenDoor()
    {
        doorLeft.DOLocalMoveX(-3, timeAnim);
        doorRight.DOLocalMoveX(3, timeAnim);
    }

    private void CloseDoor(float time)
    {
        doorLeft.DOLocalMoveX(-1, time);
        doorRight.DOLocalMoveX(1, time);
    }
}