using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 10;
    private Animator myAnimation;
    private Rigidbody2D playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myAnimation = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
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
        Vector2 playerDrection = new Vector2(moveX * speed, playerRigidbody.velocity.y);
        playerRigidbody.velocity = playerDrection;




        bool Judgement = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimation.SetBool("right", Judgement);

    }
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
