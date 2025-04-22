using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaReveal : MonoBehaviour
{
    [Header("触发设置")]
    [Tooltip("需要显示的隐藏物体")]
    public GameObject hiddenObject;

    [Tooltip("触发标签（默认Player）")]
    public string triggerTag = "Player";

    [Header("区域设置")]
    [Tooltip("触发区域范围")]
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
            Debug.Log("已触发隐藏物体显示！");
        }
    }

    void OnDrawGizmosSelected()
    {
        // 实心区域
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(transform.position, areaSize);

        // 线框边界
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, areaSize);
    }
}