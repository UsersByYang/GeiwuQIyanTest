using UnityEngine;

public class InteractionBorder : MonoBehaviour
{
    public GameObject border;
    public DialogueManager interactionAndCommunite; // ÒýÓÃ½Å±¾
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
                interactionAndCommunite.Interact();
            }
        }
    }
}