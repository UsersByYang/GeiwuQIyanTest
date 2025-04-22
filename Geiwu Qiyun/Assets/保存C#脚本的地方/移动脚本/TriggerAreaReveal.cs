using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaReveal : MonoBehaviour
{
    [Header("��������")]
    [Tooltip("��Ҫ��ʾ����������")]
    public GameObject hiddenObject;  // ��Ҫ��ʾ����������

    [Tooltip("������ǩ��Ĭ��Player��")]
    public string triggerTag = "Player"; // ��������ı�ǩ

    [Header("��������")]
    [Tooltip("��������Χ")]
    public Vector3 areaSize = new Vector3(2, 2, 2); // ����Χ

    private bool hasTriggered = false; // ��ֹ�ظ�����

    void Start()
    {
        // ��ʼ����������״̬
        if (hiddenObject != null)
        {
            hiddenObject.SetActive(false);
        }
    }

    void Update()
    {
        // ���Ƶ�������
        Debug.DrawWireCube(transform.position, areaSize, Color.green);
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

    // ��Scene��ͼ���ƴ�������
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(transform.position, areaSize);
    }
}