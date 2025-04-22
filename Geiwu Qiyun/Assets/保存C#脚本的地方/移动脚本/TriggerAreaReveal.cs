using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaReveal : MonoBehaviour
{
    [Header("触发设置")]
    [Tooltip("需要显示的隐藏物体")]
    public GameObject hiddenObject;  // 需要显示的隐藏物体

    [Tooltip("触发标签（默认Player）")]
    public string triggerTag = "Player"; // 触发对象的标签

    [Header("区域设置")]
    [Tooltip("触发区域范围")]
    public Vector3 areaSize = new Vector3(2, 2, 2); // 区域范围

    private bool hasTriggered = false; // 防止重复触发

    void Start()
    {
        // 初始化隐藏物体状态
        if (hiddenObject != null)
        {
            hiddenObject.SetActive(false);
        }
    }

    void Update()
    {
        // 绘制调试区域
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
            Debug.Log("已触发隐藏物体显示！");
        }
    }

    // 在Scene视图绘制触发区域
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(transform.position, areaSize);
    }
}