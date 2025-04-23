using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrrigerAfterDia : MonoBehaviour
{
    public GameObject mice;
    public GameObject tingweng;
    public DialogueManager2 dialogueManager;
    private bool isTrriger = false;

    // Start is called before the first frame update
    void Start()
    {
        mice.gameObject.SetActive(isTrriger);
        tingweng.gameObject.SetActive(isTrriger);

        if (dialogueManager != null)
        {
            dialogueManager.DialogueComplete += DialogueCompleted;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void DialogueCompleted()
    {
        isTrriger = true;
        mice.gameObject.SetActive(isTrriger);
        tingweng.gameObject.SetActive(isTrriger);
    }
   
}
