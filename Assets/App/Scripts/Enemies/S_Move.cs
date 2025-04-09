using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class S_Move : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float timeWaitRotate;
    [SerializeField] private float timeMove;
    [SerializeField] private float timeRotate;
    [SerializeField] private float rotateAngle;

    [Header("References")]
    [SerializeField] private Transform enemie;
    [SerializeField] private List<Transform> points;

    private int index = 0;

    private void OnEnable()
    {
        Move();
    }

    private void OnDisable()
    {
        enemie.transform.DOKill();
    }

    private void Move()
    {
        if (points == null || points.Count == 0) return;

        index = (index + 1) % points.Count;

        enemie.transform.DOMove(points[index].position, timeMove)
        .SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            StartCoroutine(DelayRotate());
        });
    }

    private IEnumerator DelayRotate()
    {
        yield return new WaitForSeconds(timeWaitRotate);

        Rotate();
    }

    private void Rotate()
    {
        Vector3 nextRotation = enemie.transform.localEulerAngles + new Vector3(0, rotateAngle, 0);

        enemie.transform.DOLocalRotate(nextRotation, timeRotate)
        .SetEase(Ease.Linear)
        .OnComplete(() =>
        {
            Move();
        });
    }
}