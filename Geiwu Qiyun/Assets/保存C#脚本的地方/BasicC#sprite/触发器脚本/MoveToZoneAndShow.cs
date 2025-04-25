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
        // 初始化数组
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
        // 查找所有带标签的物体
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("TargetObject");

        if (targetObjects.Length != targetZones.Length)
        {
            Debug.LogWarning("带标签的物体数量与目标区域数量不匹配！");
            return;
        }

        for (int i = 0; i < targetObjects.Length; i++)
        {
            // 检查每个物体是否在对应的区域内
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
