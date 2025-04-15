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
}
