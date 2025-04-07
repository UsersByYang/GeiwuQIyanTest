using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 10;
    private Animator myAnimation;
    private Rigidbody playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myAnimation = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        IsWalk();
        flip();
       
    }
    void IsWalk()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 playerDrection = new Vector3(moveX * speed, playerRigidbody.velocity.y,moveZ*speed);
        playerRigidbody.velocity = playerDrection;
        bool Judgement = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;
        bool Judgement2 = Mathf.Abs(playerRigidbody.velocity.z) > Mathf.Epsilon && playerRigidbody.velocity.z >0;
        bool Judgement3 = Mathf.Abs(playerRigidbody.velocity.z) > Mathf.Epsilon&&playerRigidbody.velocity.z<0;
        myAnimation.SetBool("right", Judgement);
      
        myAnimation.SetBool("back", Judgement2);
        
        myAnimation.SetBool("front", Judgement3);
    }
    //·´×ª
    void flip()
    {
        bool Judgement = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;
        if (Judgement)
        {
            if (playerRigidbody.velocity.x > 0.1f)
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            if (playerRigidbody.velocity.x < -0.1f)
                transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

    }
   
}
