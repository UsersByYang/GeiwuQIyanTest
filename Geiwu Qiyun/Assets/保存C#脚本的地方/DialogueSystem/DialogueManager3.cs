/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager3: MonoBehaviour
{
    public Dialogue[] dialogues;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image characterSpriteImage;
    public int currentDialogueIndex = 0;
    public int currentLineIndex = 0;
    public bool isDialogueActive = false;
    public GameObject dialogueBox;
    public float typingSpeed = 0.05f;
    private Coroutine typingCoroutine;

    private void Start()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }

    public virtual void StartDialogue()
    {
        if (dialogues.Length > 0)
        {
            isDialogueActive = true;
            if (dialogueBox != null)
            {
                dialogueBox.SetActive(true);
            }
            DisplayDialogueLine();
        }
    }

    protected void DisplayDialogueLine()
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

    public virtual void EndDialogue()
    {
        isDialogueActive = false;
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }

    public void CheckForDialogueEndAndClose()
    {
        if (currentLineIndex >= dialogues[currentDialogueIndex].lines.Length)
        {
            EndDialogue();
        }
    }
}*/



/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager3: MonoBehaviour
{
    public Dialogue[] dialogues;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image characterSpriteImage;
    public int currentDialogueIndex = 0;
    public int currentLineIndex = 0;
    public bool isDialogueActive = false;
    public GameObject dialogueBox;
    public float typingSpeed = 0.05f;
    private Coroutine typingCoroutine;

    private void Start()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }

    public virtual void StartDialogue()
    {
        if (dialogues.Length > 0)
        {
            isDialogueActive = true;
            if (dialogueBox != null)
            {
                dialogueBox.SetActive(true);
            }
            DisplayDialogueLine();
        }
    }

    protected void DisplayDialogueLine()
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

    public virtual void EndDialogue()
    {
        isDialogueActive = false;
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }

    public void CheckForDialogueEndAndClose()
    {
        if (currentLineIndex >= dialogues[currentDialogueIndex].lines.Length)
        {
            EndDialogue();
        }
    }
}*/



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
public class DialogueManager3 : MonoBehaviour
{
    public string Scene;
    public Dialogue[] dialogues;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image characterSpriteImage;
    public  int currentDialogueIndex = 0;
    private int currentLineIndex = 0;
    public bool isDialogueActive = false;
    public GameObject dialogueBox;
    public float typingSpeed = 0.05f; // ÿ���ַ���ʾ�ļ��ʱ��
    private Coroutine typingCoroutine;

    public virtual void Start()
    {
        if (dialogueBox != null) // ��ʼ���ضԻ���
        {
            dialogueBox.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        if (dialogues.Length > 0) // �жԻ����򼤻�Ի���
        {
            isDialogueActive = true;
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

    public virtual void EndDialogue()
    {
        isDialogueActive = false;
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false); // �رնԻ���
        }
        SceneManager.LoadScene(Scene);

        
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
