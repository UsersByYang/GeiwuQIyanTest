using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2 : MonoBehaviour
{
    public DialogueManager2 dialogueManager;
    private bool isInRange = false;
    private bool Trrigered = false;

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
        if (!Trrigered&&other.CompareTag("Player"))
        {
            isInRange = true;
            if (isInRange)
            {
                dialogueManager.StartDialogue();
                Destroy(this.gameObject);
            }
            Trrigered = true;
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
