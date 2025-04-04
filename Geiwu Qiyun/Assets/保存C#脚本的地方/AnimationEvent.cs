using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public void Event1()
    {
        print("ok");
    }
    public void Event2()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
