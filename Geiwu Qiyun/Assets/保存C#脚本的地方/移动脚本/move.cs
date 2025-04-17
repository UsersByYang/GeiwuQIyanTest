using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class move : MonoBehaviour
{
    private Animator playerAnimation;
    private Rigidbody playerRigidbody;

    //用于角色移动
    public float speed = 10;


    //用于拾取物品
    public GameObject myBag;
    bool isOpen;

    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        IsWalk();
        flip();

        OpenMyBag();

    }
    void IsWalk()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // 判断相反键是否同时按下
        bool oppositeX = (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D));
        bool oppositeZ = (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S));

        if (oppositeX || oppositeZ)
        {
            // 如果相反键同时按下，停止移动
            moveX = 0;
            moveZ = 0;
        }

        Vector3 playerDrection = new Vector3(moveX * speed, playerRigidbody.velocity.y, moveZ * speed);
        playerRigidbody.velocity = playerDrection;

        bool Judgement = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;
        bool Judgement2 = Mathf.Abs(playerRigidbody.velocity.z) > Mathf.Epsilon && playerRigidbody.velocity.z > 0;
        bool Judgement3 = Mathf.Abs(playerRigidbody.velocity.z) > Mathf.Epsilon && playerRigidbody.velocity.z < 0;

        playerAnimation.SetBool("right", Judgement);
        playerAnimation.SetBool("back", Judgement2);
        playerAnimation.SetBool("front", Judgement3);
    }
    //反转
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

    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);
        }
    }
  
}
    

