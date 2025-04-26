using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBorder : MonoBehaviour
{
    public GameObject border;
    public GameObject AirWall;
    public DialogueManager2 interactionAndCommunite;
    public bool isInRange = false;

    private void Start()
    {
        AirWall.gameObject.SetActive(true);
        
       
    }
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
    public virtual void isDialogue()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            interactionAndCommunite.StartDialogue();
        }
        if (interactionAndCommunite.DialogueEnd)
        {
            AirWall.gameObject.SetActive(false);
        }
    }

    /* private void Update()
     {
         if (isInRange && Input.GetKeyDown(KeyCode.E))
         {
             if (interactionAndCommunite != null)
             {
                 interactionAndCommunite.StartDialogue();
             }
         }
     }*/
     void Update()
    {
        isDialogue();
       
    }
}