using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBorder : MonoBehaviour
{
    public GameObject border;
    public DialogueManager2 interactionAndCommunite;
    private bool isInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            border.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            border.SetActive(false);
        }
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (interactionAndCommunite != null)
            {
                interactionAndCommunite.StartDialogue();
            }
        }
    }
}