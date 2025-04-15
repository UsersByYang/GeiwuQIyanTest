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
    private move playerMovement; // �Ի�ʱ���÷����
    public GameObject dialogueBox;
    public float typingSpeed = 0.05f; // ÿ���ַ���ʾ�ļ��ʱ��
    private Coroutine typingCoroutine;

    private void Start()
    {
        playerMovement = FindObjectOfType<move>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement script not found.");
        }
        if (dialogueBox != null) // ��ʼ���ضԻ���
        {
            dialogueBox.SetActive(false);
        }

        // �Զ���ʼ�Ի�
        StartDialogue();
    }

    public void StartDialogue()
    {
        if (dialogues.Length > 0) // �жԻ����򼤻�Ի���
        {
            isDialogueActive = true;
            if (playerMovement != null) // �������������ƶ�
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
            playerMovement.enabled = true; // �Ի����������������ƶ�
        }
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false); // �رնԻ���
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
            // �ж��Ƿ������һ��Ի�
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
