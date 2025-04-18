/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager1 : MonoBehaviour
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
        
        StartCoroutine(DelatedStart());
    }
    IEnumerator DelatedStart()
    {
        yield return new WaitForSeconds(5);
        playerMovement = FindObjectOfType<move>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement script not found.");
        }
        if (dialogueBox != null) // 开始隐藏对话框
        {
            dialogueBox.SetActive(false);
        }

        // 自动开始对话
        StartDialogue();

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
        CheckForDialogueEndAndClose();
        if (currentLineIndex < dialogues[currentDialogueIndex].lines.Length)
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            DialogueLine currentLine = dialogues[currentDialogueIndex].lines[currentLineIndex];
            nameText.text = currentLine.characterName;
            characterSpriteImage.sprite = currentLine.characterSprite;
            typingCoroutine = null;
            typingCoroutine = StartCoroutine(TypeDialogue(currentLine.dialogueText));
            Debug.Log("Starting new typing coroutine for line: " + currentLine.dialogueText);
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

    private void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = dialogues[currentDialogueIndex].lines[currentLineIndex - 1].dialogueText;
            }
            // 判断是否是最后一句对话
            if (currentLineIndex >= dialogues[currentDialogueIndex].lines.Length)
            {
                EndDialogue();
            }
            else
            {
                DisplayDialogueLine();
            }
        }
    }
}*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager1 : MonoBehaviour
{
    public Dialogue[] dialogues;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image characterSpriteImage;
    private int currentDialogueIndex = 0;
    private int currentLineIndex = 0;
    public bool isDialogueActive = false;
    private move playerMovement;
    public GameObject dialogueBox;
    public float typingSpeed = 0.05f;
    private Coroutine typingCoroutine;
    // 用于存储场景中的所有灯光
    public Light[] allLights;
    // 灯光渐亮的持续时间
    public float lightFadeDuration = 3f;
    public Material newSkyboxMaterial;

    private void Start()
    {
        StartCoroutine(DelatedStart());
    }

    IEnumerator DelatedStart()
    {
        yield return new WaitForSeconds(5);
        playerMovement = FindObjectOfType<move>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement script not found.");
        }
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }

        StartDialogue();
    }

    public void StartDialogue()
    {
        if (dialogues.Length > 0)
        {
            isDialogueActive = true;
            if (playerMovement != null)
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
        CheckForDialogueEndAndClose();
        if (currentLineIndex < dialogues[currentDialogueIndex].lines.Length)
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            DialogueLine currentLine = dialogues[currentDialogueIndex].lines[currentLineIndex];
            nameText.text = currentLine.characterName;
            characterSpriteImage.sprite = currentLine.characterSprite;
            typingCoroutine = null;
            typingCoroutine = StartCoroutine(TypeDialogue(currentLine.dialogueText));
            Debug.Log("Starting new typing coroutine for line: " + currentLine.dialogueText);
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
            playerMovement.enabled = true;
        }
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
            ChangeSkybox();
        }
        // 新增：对话结束后启动灯光渐亮协程
        StartCoroutine(FadeLightsOn());
    }

    // 新增：灯光渐亮的协程
    private IEnumerator FadeLightsOn()
    {
        foreach (Light light in allLights)
        {
            light.gameObject.SetActive(true);
            light.intensity = 0f;
        }
        float elapsedTime = 0;
        while (elapsedTime < lightFadeDuration)
        {
            foreach (Light light in allLights)
            {
                light.intensity = Mathf.Lerp(0f, 1f, elapsedTime / lightFadeDuration);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // 确保最后灯光强度为1
        foreach (Light light in allLights)
        {
            light.intensity = 1f;
        }
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

    private void Update()
    {
        // 如果对话处于激活状态且玩家按下了E键
        if (isDialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            // 如果打字协程正在运行
            if (typingCoroutine != null)
            {
                // 停止打字协程
                StopCoroutine(typingCoroutine);
                // 将对话文本直接设置为当前行完整的对话内容
                dialogueText.text = dialogues[currentDialogueIndex].lines[currentLineIndex - 1].dialogueText;
            }
            // 判断当前行索引是否大于等于当前对话的总行数，即是否是最后一句对话
            if (currentLineIndex >= dialogues[currentDialogueIndex].lines.Length)
            {
                // 结束对话
                EndDialogue();
            }
            else
            {
                // 显示下一行对话
                DisplayDialogueLine();
            }
        }
    }
}