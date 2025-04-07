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

    private void OnEnable()
    {
        rseOpenDoor.action += HandleDoor;
    }

    private void OnDisable()
    {
        rseOpenDoor.action -= HandleDoor;
    }

    private void HandleDoor(bool value)
    {
        if (value)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        doorLeft.DOLocalMoveX(-3, timeAnim);
        doorRight.DOLocalMoveX(3, timeAnim);
    }

    private void CloseDoor()
    {
        doorLeft.DOLocalMoveX(-1, timeAnim);
        doorRight.DOLocalMoveX(1, timeAnim);
    }
}