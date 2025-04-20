/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance; // ����

    [Header("��������")]
    public string nextSceneName; // Ŀ�곡������
    public float sceneSwitchDelay = 1f; // ��ת�ӳ٣���ѡ��

    private int totalItems; // ��������Ʒ����
    private int collectedItems; // ���ռ���Ʒ��

    void Awake()
    {
        // ����ģʽȷ��Ψһ��
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // ��ʼ��ʱͳ�Ƴ�����������Ʒ
        UpdateTotalItems();
    }

    // ���³����е���Ʒ���������ֶ����ã�
    public void UpdateTotalItems()
    {
        totalItems = FindObjectsOfType<ItemOnWorld>().Length;
        collectedItems = 0; // ���ü���
    }

    // ����Ʒ���ռ�ʱ����
    public void OnItemCollected()
    {
        collectedItems++;
        CheckAllItemsCollected();
    }

    // ����Ƿ�������Ʒ�����ռ�
    private void CheckAllItemsCollected()
    {
        if (collectedItems >= totalItems)
        {
            // �ӳ���ת����ѡ��
            Invoke(nameof(LoadNextScene), sceneSwitchDelay);
        }
    }

    // ��ת��Ŀ�곡��
    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("δ����Ŀ�곡�����ƣ�");
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance; // ����

    [Header("��������")]
    public string nextSceneName; // Ŀ�곡������
    public float sceneSwitchDelay = 1f; // ��ת�ӳ٣���ѡ��

    [Header("�Ի�����")]
    public GameObject dialogueObject; // ���ضԻ��ű���Ŀ������
    private Isdialogue dialogueScript; // �Ի��ű�����

    private int totalItems; // ��������Ʒ����
    private int collectedItems; // ���ռ���Ʒ��

    void Awake()
    {
        // ����ģʽȷ��Ψһ��
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // ��ȡ�Ի��ű�����
        if (dialogueObject != null)
        {
            dialogueScript = dialogueObject.GetComponent<Isdialogue>();
        }
        else
        {
            Debug.LogError("δ���öԻ����壡");
        }
    }

    void Start()
    {
        // ��ʼ��ʱͳ�Ƴ�����������Ʒ
        UpdateTotalItems();
    }

    // ���³����е���Ʒ���������ֶ����ã�
    public void UpdateTotalItems()
    {
        totalItems = FindObjectsOfType<ItemOnWorld>().Length;
        collectedItems = 0; // ���ü���
    }

    // ����Ʒ���ռ�ʱ����
    public void OnItemCollected()
    {
        collectedItems++;
        CheckAllItemsCollected();
    }

    // ����Ƿ�������Ʒ�����ռ�
    private void CheckAllItemsCollected()
    {
        if (collectedItems >= totalItems)
        {
            // �ӳ���ת����ѡ��
            Invoke(nameof(LoadNextScene), sceneSwitchDelay);

            // ���öԻ��ű�
            if (dialogueScript != null)
            {
                dialogueScript.IsDialogue();
            }
        }
    }

    // ��ת��Ŀ�곡��
    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("δ����Ŀ�곡�����ƣ�");
        }
    }
}