using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Isdialogue : DialogueManager2
{
    public string scene;
    private bool isDialogueInProgress = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        CheckForDialogueInput();
    }

    private void CheckForDialogueInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && ItemManager.Instance.AreAllItemsCollected() && !isDialogueInProgress)
        {
            StartDialogue();
            isDialogueInProgress = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !ItemManager.Instance.AreAllItemsCollected())
        {
            Debug.Log("物品还未全部收集，无法对话");
        }
    }

    
    public override void EndDialogue()
    {
        base.EndDialogue();
        if (ItemManager.Instance.AreAllItemsCollected())
        {
            SceneManager.LoadScene(scene);
        }
        isDialogueInProgress = false;
    }


}

