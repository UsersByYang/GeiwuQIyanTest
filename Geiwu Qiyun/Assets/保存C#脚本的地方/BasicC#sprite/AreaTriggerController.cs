using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AreaTriggerController : MonoBehaviour
{
    [Header("��������")]
    [Tooltip("���뾶����λ���ף�")]
    public float detectionRadius = 5f;

    [Header("��������")]
    [Tooltip("��Ҫ���������ǩ")]
    public string targetTag = "Player";

    [Header("���ӻ�")]
    [Tooltip("�Ƿ���ʾ��ⷶΧ")]
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
        // ��ǩ���˼��
        if (!other.CompareTag(targetTag)) return;

        // �ų�û�и��������
        if (!other.attachedRigidbody) return;

        if (!originalStates.ContainsKey(other))
        {
            originalStates[other] = other.isTrigger;
            other.isTrigger = true;
            Debug.Log($"{other.name} ���뷶Χ��������Is Trigger");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // ��ǩ���˼��
        if (!other.CompareTag(targetTag)) return;

        if (originalStates.TryGetValue(other, out bool originalState))
        {
            other.isTrigger = originalState;
            originalStates.Remove(other);
            Debug.Log($"{other.name} �뿪��Χ���ѻָ�Is Trigger");
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
