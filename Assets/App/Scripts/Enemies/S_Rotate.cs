using System.Collections;
using UnityEngine;
using DG.Tweening;

public class S_Rotate : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private float timeWaitRotate;
	[SerializeField] private float timeRotate;
    [SerializeField] private float rotateAngle;

    private void OnEnable()
	{
		StartCoroutine(DelayRotate());
	}

    private void OnDisable()
    {
        transform.DOKill();
        StopAllCoroutines();
    }

    private IEnumerator DelayRotate()
	{
		yield return new WaitForSeconds(timeWaitRotate);

		Rotate();
    }

	private void Rotate()
	{
        Vector3 nextRotation = transform.localEulerAngles + new Vector3(0, rotateAngle, 0);

        transform.DOLocalRotate(nextRotation, timeRotate).OnComplete(() =>
        {
            StartCoroutine(DelayRotate());
        });
    }
}