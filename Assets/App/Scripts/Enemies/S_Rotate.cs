using System.Collections;
using UnityEngine;
using DG.Tweening;

public class S_Rotate : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private float timeWaitRotate;
	[SerializeField] private float timeRotate;

	//[Header("References")]

	//[Header("Input")]

	//[Header("Output")]

	private void OnEnable()
	{
		StartCoroutine(Rotate());
	}

	private IEnumerator Rotate()
	{
		yield return new WaitForSeconds(5);

		transform.DOLocalRotate(new Vector3(0, -90), timeRotate).OnComplete(()=>
		{
			StartCoroutine(Rotate());
		});
	}
}