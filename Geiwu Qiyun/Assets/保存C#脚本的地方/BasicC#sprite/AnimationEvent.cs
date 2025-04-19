using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvent : MonoBehaviour
{
    // Start is called before the first frame update

   /* void Start()
    {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
            yield return new WaitForSeconds(2f);
            Event1();
            Event2();
    }*/

    public void Event1()
    {
        print("ok");
    }

    public void Event2()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
