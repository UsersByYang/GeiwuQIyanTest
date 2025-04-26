using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject uiElement; // ��Ҫ���Ƶ�UIԪ��
    [SerializeField] private KeyCode toggleKey = KeyCode.T; // ��Ϊ T ������

    [Header("Settings")]
    [SerializeField] private bool startHidden = true; // ��ʼ�Ƿ�����

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
    /// �л�UI��ʾ״̬
    /// </summary>
    public void ToggleUI()
    {
        if (uiElement != null)
        {
            uiElement.SetActive(!uiElement.activeSelf);
        }
        else
        {
            Debug.LogWarning("UI Element δ��ֵ��");
        }
    }
}