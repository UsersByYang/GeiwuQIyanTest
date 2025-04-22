using UnityEngine;
using UnityEngine.UI;


public class DialogueButton1 : MonoBehaviour
{
   
    private DialogueManager3 dialogueManager;
    private Button button1;

    private void Start()
    {
        // ��ȡDialogueManager3���
        dialogueManager = FindObjectOfType<DialogueManager3>();
        if (dialogueManager == null)
        {
            Debug.LogError("DialogueManager3 script not found.");
        }

        // ��ȡ��ť�������ӵ���¼�������
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
        // �����ťʱ������DialogueManager3��StartDialogue����
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