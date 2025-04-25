using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AreaTrgger : MonoBehaviour
{
    [Header("Settings")]
    public string targetTag = "Movable"; // 需要匹配的标签
    private bool isCompleted;

    private void OnTriggerEnter(Collider other)
    {
        if (!isCompleted && other.CompareTag(targetTag))
        {
            isCompleted = true;
            AreaManager.Instance.RegisterAreaCompletion();
        }
    }
}