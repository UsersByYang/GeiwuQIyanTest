using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
{
    public DialogueManager2 dialogueManager;
    private bool isInRange = false;
    public GameObject dialogueBoxToClose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            if (isInRange)
            {
                dialogueManager.StartDialogue();
                StartCoroutine(CloseDialogueBoxAfterDelay());
                Destroy(this.gameObject);
            }
        }
    }

    private IEnumerator CloseDialogueBoxAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        if (dialogueBoxToClose != null)
        {
            dialogueBoxToClose.gameObject. SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
