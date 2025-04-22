using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaReveal : MonoBehaviour
{
    [Header("��������")]
    [Tooltip("��Ҫ��ʾ����������")]
    public GameObject hiddenObject;

    [Tooltip("������ǩ��Ĭ��Player��")]
    public string triggerTag = "Player";

    [Header("��������")]
    [Tooltip("��������Χ")]
    public Vector3 areaSize = new Vector3(2, 2, 2);

    private bool hasTriggered = false;

    void Start()
    {
        if (hiddenObject != null)
        {
            hiddenObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag(triggerTag))
        {
            RevealHiddenObject();
        }
    }

    void RevealHiddenObject()
    {
        if (hiddenObject != null)
        {
            hiddenObject.SetActive(true);
            hasTriggered = true;
            Debug.Log("�Ѵ�������������ʾ��");
        }
    }

    void OnDrawGizmosSelected()
    {
        // ʵ������
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(transform.position, areaSize);

        // �߿�߽�
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, areaSize);
    }
}