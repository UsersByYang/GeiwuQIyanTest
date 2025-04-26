//���������һ�α�д�Ľű�
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
            //Invoke(nameof(LoadNextScene), sceneSwitchDelay);
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
    public DialogueManager2 dialogueManager1;//�ռ�����Ʒǰ
    public DialogueManagerAuto dialogueManager2;//������Ʒ��
    public FadeAndLoadScene2 fadeandloadscene;//��ת

    [Header("��������")]
    public string nextSceneName; // Ŀ�곡������
    public float sceneSwitchDelay = 1f; // ��ת�ӳ٣���ѡ��

    protected int totalItems; // ��������Ʒ����
    public int collectedItems; // ���ռ���Ʒ��

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

    public void Start()
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
    public virtual void CheckAllItemsCollected()
    {
       

            if (collectedItems >= totalItems)
            {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueManager1.StartDialogue();
            }
                if (dialogueManager1.DialogueEnd)
                {
  
                        fadeandloadscene.Load();
                   
                }


                else if (dialogueManager1 == null && dialogueManager2 == null)
                {
                    fadeandloadscene.Load();
                }


            }
               
    }

    // ��ת��Ŀ�곡��
    //�������FadeAndLoadScene�Ľű�����ת���ܣ��Ͳ����ˣ�
    /*private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("δ����Ŀ�곡�����ƣ�");
        }
    }*/
}