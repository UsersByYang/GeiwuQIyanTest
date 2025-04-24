using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AreaTriggerController : MonoBehaviour
{
    [Header("基础设置")]
    [Tooltip("检测半径（单位：米）")]
    public float detectionRadius = 5f;

    [Header("过滤设置")]
    [Tooltip("需要检测的物体标签")]
    public string targetTag = "Player";

    [Header("可视化")]
    [Tooltip("是否显示检测范围")]
    public bool showGizmos = true;

    private SphereCollider areaCollider;
    private Dictionary<Collider, bool> originalStates = new Dictionary<Collider, bool>();

    void Awake()
    {
        ConfigureCollider();
    }

    void ConfigureCollider()
    {
        areaCollider = GetComponent<SphereCollider>();
        areaCollider ??= gameObject.AddComponent<SphereCollider>();

        areaCollider.isTrigger = true;
        areaCollider.radius = detectionRadius;
    }

    void OnValidate()
    {
        if (areaCollider != null)
        {
            areaCollider.radius = detectionRadius;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 标签过滤检查
        if (!other.CompareTag(targetTag)) return;

        // 排除没有刚体的物体
        if (!other.attachedRigidbody) return;

        if (!originalStates.ContainsKey(other))
        {
            originalStates[other] = other.isTrigger;
            other.isTrigger = true;
            Debug.Log($"{other.name} 进入范围，已启用Is Trigger");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 标签过滤检查
        if (!other.CompareTag(targetTag)) return;

        if (originalStates.TryGetValue(other, out bool originalState))
        {
            other.isTrigger = originalState;
            originalStates.Remove(other);
            Debug.Log($"{other.name} 离开范围，已恢复Is Trigger");
        }
    }

    void OnDrawGizmosSelected()
    {
        if (!showGizmos) return;

        Gizmos.color = new Color(1, 0.92f, 0.016f, 0.3f);
        Gizmos.DrawSphere(transform.position, detectionRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
