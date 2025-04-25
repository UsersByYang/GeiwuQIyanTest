using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToZoneAndShow : MonoBehaviour
{
    public Transform resultObject;
    public Transform[] targetZones;
    private int objectsInZoneCount = 0;
    private bool[] objectsInZone = new bool[4];

    private void Start()
    {
        // ��ʼ������
        for (int i = 0; i < objectsInZone.Length; i++)
        {
            objectsInZone[i] = false;
        }

        if (resultObject != null)
        {
            resultObject.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // �������д���ǩ������
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("TargetObject");

        if (targetObjects.Length != targetZones.Length)
        {
            Debug.LogWarning("����ǩ������������Ŀ������������ƥ�䣡");
            return;
        }

        for (int i = 0; i < targetObjects.Length; i++)
        {
            // ���ÿ�������Ƿ��ڶ�Ӧ��������
            if (Vector3.Distance(targetObjects[i].transform.position, targetZones[i].position) < 2f)
            {
                if (!objectsInZone[i])
                {
                    objectsInZone[i] = true;
                    objectsInZoneCount++;
                }
            }
            else
            {
                if (objectsInZone[i])
                {
                    objectsInZone[i] = false;
                    objectsInZoneCount--;
                }
            }
        }

        if (objectsInZoneCount == targetZones.Length && resultObject != null)
        {
            resultObject.gameObject.SetActive(true);
        }
        else if (resultObject != null)
        {
            resultObject.gameObject.SetActive(false);
        }
    }
}
