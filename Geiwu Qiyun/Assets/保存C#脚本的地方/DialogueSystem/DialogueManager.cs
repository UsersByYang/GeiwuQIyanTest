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
    private move playerMovement;//�Ի�ʱ���÷���
    public GameObject dialogueBox;


    private void Start()
    {
        playerMovement = FindObjectOfType<move>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement script not found.");
        }
        if (dialogueBox != null)//��ʼ���ضԻ���
        {
            dialogueBox.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        if (dialogues.Length > 0)//�жԻ����򼤻�Ի���
        {
            isDialogueActive = true;
            if (playerMovement != null)//������ӹ�����ƶ�
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
            playerMovement.enabled = true;//�Ի����������������ƶ�
        }
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);//�رնԻ���
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
