using System.Collections.Generic;
using UnityEngine;

public class S_Spawn : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]
    [SerializeField] private List<Transform> points;

    //[Header("Input")]

    //[Header("Output")]

    public List<Transform> GetPoints()
    {
        return points;
    }
}