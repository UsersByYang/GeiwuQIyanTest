using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenceUpdate : MonoBehaviour
{
    public bool useClick = true;
    public bool useCollision = false;
    public bool goToNextScene = false;
    public string nextSceneName = "WuZhiScence";
    public GameObject popup;

    private void Update()
    {
        if (useClick && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    HandleInteraction();
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (useCollision && collision.gameObject.CompareTag("Player"))
        {
            HandleInteraction();
        }
    }

    private void HandleInteraction()
    {
        if (popup != null)
        {
            popup.SetActive(true);
        }

        if (goToNextScene)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
