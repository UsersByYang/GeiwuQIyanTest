using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isdialogue : DialogueManager2
{
    private ItemOnWorld itemPickup;

    // Start is called before the first frame update
    void Start()
    {
        itemPickup = FindObjectOfType<ItemOnWorld>();
        if (itemPickup == null)
        {
            Debug.LogError("ItemPickup script not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IsDialogue()
    {
        if (itemPickup != null && itemPickup.isItemPicked)
        {
            currentLineIndex = 0;
            StartDialogue();
        }
        else
        {
            Debug.Log("You need to pick up the item first.");
        }
    }
}
