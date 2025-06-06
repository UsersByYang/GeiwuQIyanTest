using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Dialogue[] dialogues;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image characterSpriteImage;
    private int currentDialogueIndex = 0;
    private int currentLineIndex = 0;
    public bool isDialogueActive = false;
    private move playerMovement; // 对话时禁用方向键
    public GameObject dialogueBox;
    public float typingSpeed = 0.05f; // 每个字符显示的间隔时间
    private Coroutine typingCoroutine;

    // 要切换到的天空盒材质
    public Material newSkyboxMaterial;

    // 用于引用场景中的Directional Light
    public Light directionalLight;

    private void Start()
    {
        playerMovement = FindObjectOfType<move>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement script not found.");
        }
        if (dialogueBox != null) // 开始隐藏对话框
        {
            dialogueBox.SetActive(false);
        }

        if (directionalLight != null)
        {
            directionalLight.gameObject.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        if (dialogues.Length > 0) // 有对话，则激活对话框
        {
            isDialogueActive = true;
            if (playerMovement != null) // 激活后禁用人物移动
            {
                playerMovement.enabled = false;
            }
            if (dialogueBox != null)
            {
                dialogueBox.SetActive(true);
            }
            DisplayDialogueLine();
        }
    }

    private void DisplayDialogueLine()
    {
        if (currentLineIndex < dialogues[currentDialogueIndex].lines.Length)
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            DialogueLine currentLine = dialogues[currentDialogueIndex].lines[currentLineIndex];
            nameText.text = currentLine.characterName;
            characterSpriteImage.sprite = currentLine.characterSprite;
            typingCoroutine = StartCoroutine(TypeDialogue(currentLine.dialogueText));
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    private IEnumerator TypeDialogue(string line)
    {
        dialogueText.text = "";
        foreach (char c in line.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public virtual  void EndDialogue()
    {
        isDialogueActive = false;
        if (playerMovement != null)
        {
            playerMovement.enabled = true; // 对话结束，激活人物移动
        }
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false); // 关闭对话框
        }

        // 打开Directional Light
        if (directionalLight != null)
        {
            directionalLight.gameObject.SetActive(true);
        }

        // 延迟3秒调用ChangeSkybox方法
        Invoke("ChangeSkybox", 1f);
    }

    private void ChangeSkybox()
    {
        if (newSkyboxMaterial != null)
        {
            RenderSettings.skybox = newSkyboxMaterial;
        }
        else
        {
            Debug.LogError("New skybox material is not assigned.");
        }
    }

    public void CheckForDialogueEndAndClose()
    {
        if (currentLineIndex >= dialogues[currentDialogueIndex].lines.Length)
        {
            EndDialogue();
        }
    }
}




//原代码
/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Dialogue[] dialogues;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image characterSpriteImage;
    private int currentDialogueIndex = 0;
    private int currentLineIndex = 0;
    public bool isDialogueActive = false;
    private move playerMovement; // 对话时禁用方向键
    public GameObject dialogueBox;
    public float typingSpeed = 0.05f; // 每个字符显示的间隔时间
    private Coroutine typingCoroutine;

    private void Start()
    {
        playerMovement = FindObjectOfType<move>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement script not found.");
        }
        if (dialogueBox != null) // 开始隐藏对话框
        {
            dialogueBox.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        if (dialogues.Length > 0) // 有对话，则激活对话框
        {
            isDialogueActive = true;
            if (playerMovement != null) // 激活后禁用人物移动
            {
                playerMovement.enabled = false;
            }
            if (dialogueBox != null)
            {
                dialogueBox.SetActive(true);
            }
            DisplayDialogueLine();
        }
    }

    private void DisplayDialogueLine()
    {
        if (currentLineIndex < dialogues[currentDialogueIndex].lines.Length)
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            DialogueLine currentLine = dialogues[currentDialogueIndex].lines[currentLineIndex];
            nameText.text = currentLine.characterName;
            characterSpriteImage.sprite = currentLine.characterSprite;
            typingCoroutine = StartCoroutine(TypeDialogue(currentLine.dialogueText));
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    private IEnumerator TypeDialogue(string line)
    {
        dialogueText.text = "";
        foreach (char c in line.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        if (playerMovement != null)
        {
            playerMovement.enabled = true; // 对话结束，激活人物移动
        }
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false); // 关闭对话框
        }
    }

    public void CheckForDialogueEndAndClose()
    {
        if (currentLineIndex >= dialogues[currentDialogueIndex].lines.Length)
        {
            EndDialogue();
        }
    }
}
*/
