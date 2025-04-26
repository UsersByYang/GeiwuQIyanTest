using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject uiElement; // 需要控制的UI元素
    [SerializeField] private KeyCode toggleKey = KeyCode.T; // 改为 T 键触发

    [Header("Settings")]
    [SerializeField] private bool startHidden = true; // 初始是否隐藏

    private void Start()
    {
        if (uiElement != null && startHidden)
        {
            uiElement.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleUI();
        }
    }

    /// <summary>
    /// 切换UI显示状态
    /// </summary>
    public void ToggleUI()
    {
        if (uiElement != null)
        {
            uiElement.SetActive(!uiElement.activeSelf);
        }
        else
        {
            Debug.LogWarning("UI Element 未赋值！");
        }
    }
}