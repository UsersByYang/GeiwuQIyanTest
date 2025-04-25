using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueAndSceneSwitch : start
{
    public string sceneToLoad; 
    public float delayBeforeLoad = 1f; 

    public override void EndDialogue()
    {
        base.EndDialogue();
     
        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}