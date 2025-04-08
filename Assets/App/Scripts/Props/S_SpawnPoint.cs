using UnityEngine;

public class S_SpawnPoint : MonoBehaviour
{
    [Header("Output")]
    [SerializeField] private RSE_SpawnPoint rseSpawnPoint;

    private void OnEnable()
    {
        StartCoroutine(S_Utils.DelayFrame(() => rseSpawnPoint.Call(transform.position)));
    }
}