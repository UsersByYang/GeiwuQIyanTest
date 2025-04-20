using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiaAndToNextScene : DialogueManager2
{
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*public override void StartDialogue()
    {
        if (ItemManager.Instance.AreAllItemsCollected() && dialogues.Length > 0)
        {
            isDialogueActive = true;
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }
            if (dialogueBox != null)
            {
                dialogueBox.SetActive(true);
            }
            DisplayDialogueLine();
        }
    }
    */
    public override void EndDialogue()
    {
        base.EndDialogue();
        SceneManager.LoadScene(scene);
    }
}
