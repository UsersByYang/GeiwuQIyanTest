using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trriger : MonoBehaviour
{
    public DialogueManager3 dialogueManager;
    private bool isInRange = false;
    public DingMove dingmove;


    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && dingmove.isDropped)
        {
            dialogueManager.StartDialogue();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ding"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ding"))
        {
            isInRange = false;
        }
    }

}
