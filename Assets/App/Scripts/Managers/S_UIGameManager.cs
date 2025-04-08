using UnityEngine;

public class S_UIGameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform spawnPoint;

    [Header("Input")]
    [SerializeField] private RSO_Item rsoItem;

    [Header("Output")]
    [SerializeField] private RSE_HideMouseCursor rseHideMouseCursor;
    [SerializeField] private RSE_SpawnPoint rseSpawnPoint;

    private void OnEnable()
    {
        rseHideMouseCursor.Call();
        rsoItem.Value = false;
        StartCoroutine(S_Utils.Delay(0.1f, () => rseSpawnPoint.Call(spawnPoint.position)));
    }
}