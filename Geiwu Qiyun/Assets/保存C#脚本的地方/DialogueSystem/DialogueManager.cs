using System;
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
    private move playerMovement;//对话时禁用方向建
    public GameObject dialogueBox;


    private void Start()
    {
        playerMovement = FindObjectOfType<move>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement script not found.");
        }
        if (dialogueBox != null)//开始隐藏对话框
        {
            dialogueBox.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        if (dialogues.Length > 0)//有对话，则激活对话框
        {
            isDialogueActive = true;
            if (playerMovement != null)//激活后金庸人物移动
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
            DialogueLine currentLine = dialogues[currentDialogueIndex].lines[currentLineIndex];
            nameText.text = currentLine.characterName;
            dialogueText.text = currentLine.dialogueText;
            characterSpriteImage.sprite = currentLine.characterSprite;
            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        if (playerMovement != null)
        {
            playerMovement.enabled = true;//对话结束，激活人物移动
        }
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);//关闭对话框
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
