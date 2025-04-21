using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparaAnimateManager : MonoBehaviour
{
    private Animator ApparatusAnimatior;
    // Start is called before the first frame update
    void Start()
    {
        ApparatusAnimatior = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AnimationTrriger()
    {
        
        ApparatusAnimatior.SetBool("start", true);
        ApparatusAnimatior.SetBool("pull", true);
        ApparatusAnimatior.SetBool("move", true);
        ApparatusAnimatior.SetBool("down", true);
        ApparatusAnimatior.SetBool("idle", true);
    }
}
