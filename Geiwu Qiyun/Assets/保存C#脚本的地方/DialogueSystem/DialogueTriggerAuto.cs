using UnityEngine;

public class DialogueTriggerAuto : MonoBehaviour
{
    public DialogueManagerAuto dialogueManager2;
    private bool isInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private void Update()
    {
        if (isInRange)
        {
            dialogueManager2.StartDialogue();
            Destroy(this.gameObject);
        }
    }
}