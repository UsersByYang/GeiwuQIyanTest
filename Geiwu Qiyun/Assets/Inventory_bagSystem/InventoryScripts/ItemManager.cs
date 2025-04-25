/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
   
    public static ItemManager Instance; // 单例

    [Header("场景设置")]
    public string nextSceneName; // 目标场景名称
    public float sceneSwitchDelay = 1f; // 跳转延迟（可选）

    private int totalItems; // 场景中物品总数
    private int collectedItems; // 已收集物品数

    void Awake()
    {
        // 单例模式确保唯一性
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
        // 初始化时统计场景中所有物品
        UpdateTotalItems();
    }

    // 更新场景中的物品总数（可手动调用）
    public void UpdateTotalItems()
    {
        totalItems = FindObjectsOfType<ItemOnWorld>().Length;
        collectedItems = 0; // 重置计数
    }

    // 当物品被收集时调用
    public void OnItemCollected()
    {
        collectedItems++;
        CheckAllItemsCollected();
    }

    // 检测是否所有物品均被收集
    private void CheckAllItemsCollected()
    {
        if (collectedItems >= totalItems)
        {
            
            // 延迟跳转（可选）
            //Invoke(nameof(LoadNextScene), sceneSwitchDelay);
        }
    }

    // 跳转到目标场景
    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("未设置目标场景名称！");
        }
    }
    //判断
    public bool AreAllItemsCollected()
    {
        return collectedItems >= totalItems;
    }
}*/








//这里是你第一次编写的脚本
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance; // 单例

    [Header("场景设置")]
    public string nextSceneName; // 目标场景名称
    public float sceneSwitchDelay = 1f; // 跳转延迟（可选）

    [Header("对话设置")]
    public GameObject dialogueObject; // 挂载对话脚本的目标物体
    private Isdialogue dialogueScript; // 对话脚本引用

    private int totalItems; // 场景中物品总数
    private int collectedItems; // 已收集物品数

    void Awake()
    {
        // 单例模式确保唯一性
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // 获取对话脚本引用
        if (dialogueObject != null)
        {
            dialogueScript = dialogueObject.GetComponent<Isdialogue>();
        }
        else
        {
            Debug.LogError("未设置对话物体！");
        }
    }

    void Start()
    {
        // 初始化时统计场景中所有物品
        UpdateTotalItems();
    }

    // 更新场景中的物品总数（可手动调用）
    public void UpdateTotalItems()
    {
        totalItems = FindObjectsOfType<ItemOnWorld>().Length;
        collectedItems = 0; // 重置计数
    }

    // 当物品被收集时调用
    public void OnItemCollected()
    {
        collectedItems++;
        CheckAllItemsCollected();
    }

    // 检测是否所有物品均被收集
    private void CheckAllItemsCollected()
    {
        if (collectedItems >= totalItems)
        {
            // 启用对话脚本
            if (dialogueScript != null)
            {
                dialogueScript.StartDialogue();
                Invoke(nameof(LoadNextScene), sceneSwitchDelay);
            }
            // 延迟跳转（可选）
            

            
        }
    }

    // 跳转到目标场景
    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("未设置目标场景名称！");
        }
    }
}*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance; // 单例
    public DialogueManager2 dialogueManager1;//收集完物品前
    public DialogueManagerAuto dialogueManager2;//剪完物品后；
    public FadeAndLoadScene2 fadeandloadscene;//跳转

    [Header("场景设置")]
    public string nextSceneName; // 目标场景名称
    public float sceneSwitchDelay = 1f; // 跳转延迟（可选）

    protected int totalItems; // 场景中物品总数
    protected int collectedItems; // 已收集物品数

    void Awake()
    {
        // 单例模式确保唯一性
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
        // 初始化时统计场景中所有物品
        UpdateTotalItems();
    }

    // 更新场景中的物品总数（可手动调用）
    public void UpdateTotalItems()
    {
        totalItems = FindObjectsOfType<ItemOnWorld>().Length;
        collectedItems = 0; // 重置计数
    }

    // 当物品被收集时调用
    public void OnItemCollected()
    {
        collectedItems++;
        CheckAllItemsCollected();
    }

    // 检测是否所有物品均被收集
    public virtual void CheckAllItemsCollected()
    {
        if (collectedItems >= totalItems)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueManager1.StartDialogue();

            }

            if (dialogueManager1.DialogueEnd)//这里是代表已经和鼎交互
            {

                    dialogueManager2.StartDialogue();
                    if (dialogueManager1.DialogueEnd && dialogueManager2.DialogueEnd)//同时对话结束跳转
                    {
                        fadeandloadscene.Load();
                    }
            }
            
           
            // 延迟跳转（可选）
            //Invoke(nameof(LoadNextScene), sceneSwitchDelay);
        }
       
    }

    // 跳转到目标场景
    //这里调用FadeAndLoadScene的脚本的跳转功能，就不用了；
    /*private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("未设置目标场景名称！");
        }
    }*/
}