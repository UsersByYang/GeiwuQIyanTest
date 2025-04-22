using UnityEngine;
using UnityEngine.UI;


public class DialogueButton1 : MonoBehaviour
{
   
    private DialogueManager3 dialogueManager;
    private Button button1;

    private void Start()
    {
        // 获取DialogueManager3组件
        dialogueManager = FindObjectOfType<DialogueManager3>();
        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager3 script not found.");
        }

        // 获取按钮组件并添加点击事件监听器
         button1 = GetComponent<Button>();
        if (button1 != null)
        {
            button1.onClick.AddListener(OnButtonClick);
          
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject.");
        }
    }

    private void OnButtonClick()
    {
        // 点击按钮时，调用DialogueManager3的StartDialogue方法
        if (dialogueManager != null)
        {
            dialogueManager.StartDialogue();
        }
        if (button1 != null)
        {

            button1.gameObject.SetActive(false);
        }
        
    }
}