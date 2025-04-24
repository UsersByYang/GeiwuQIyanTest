using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManagerAuto: DialogueManager2
{
    public float autoAdvanceInterval = 2f; // 自动跳转时间
    private Coroutine autoAdvanceCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void StartDialogue()
    {
        base.StartDialogue();
        autoAdvanceCoroutine = StartCoroutine(AutoAdvanceDialogue());
    }

    public override void EndDialogue()
    {
        base.EndDialogue();
        if (autoAdvanceCoroutine != null)
        {
            StopCoroutine(autoAdvanceCoroutine);
            autoAdvanceCoroutine = null;
        }
    }

    private IEnumerator AutoAdvanceDialogue()
    {
        while (isDialogueActive)
        {
            yield return new WaitForSeconds(autoAdvanceInterval);
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = dialogues[currentDialogueIndex].lines[currentLineIndex - 1].dialogueText;
            }
            DisplayDialogueLine();
        }
    }
}
