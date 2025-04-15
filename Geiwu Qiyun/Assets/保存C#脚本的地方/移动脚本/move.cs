using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class move : MonoBehaviour
{
    private Animator playerAnimation;
    //private Animator stoneAnimation;
    private Rigidbody playerRigidbody;

    //用于角色移动
    public float speed = 10;


    //用于拾取物品
    public GameObject myBag;
    bool isOpen;

    //用于推石头和石头滚动动画
    //角色接触石头且按住方向键播放推石头动画，大于某个时间后石头移动，停止推石头动画，播放石头滚动动画
   /* public GameObject Stone;
    private bool isPushing = false;
    private float pushStartTime;
    public float pushDuration = 3;*/
    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        //stoneAnimation = GetComponent<Animator>();
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
   /* void PushStone()
    {
        if (isPushing)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            // 如果有水平或垂直方向的输入
            if (horizontalInput != 0 || verticalInput != 0)
            {
                // 设置角色Animator的IsPushing参数为true，以播放推石头动画
                playerAnimation.SetBool("IsPushing", true);

                // 检查从开始推石头到现在的时间是否达到了设定的推石头持续时间
                if (Time.time - pushStartTime >= pushDuration)
                {
                    // 停止推石头状态
                    isPushing = false;
                    // 设置角色Animator的IsPushing参数为false，停止播放推石头动画
                    playerAnimation.SetBool("IsPushing", false);
                    // 设置石头Animator的IsRolling参数为true，以播放石头滚动动画
                    stoneAnimation.SetBool("IsRolling", true);

                    // 这里简单示例让石头沿角色前方移动，通过获取角色的前向向量
                    Vector3 moveDirection = transform.forward;
                    // 给石头的刚体添加一个向前的冲力，使其移动
                    Stone.GetComponent<Rigidbody>().AddForce(moveDirection * 5f, ForceMode.Impulse);
                }
            }
            else
            {
                // 如果没有水平或垂直方向的输入，设置角色Animator的IsPushing参数为false，停止播放推石头动画
                playerAnimation.SetBool("IsPushing", false);
            }
        }
    }*/
    //检测石头
   /* void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Stone)
        {
            isPushing = true;
            pushStartTime = Time.time;
        }
    }*/
}
    

//原代码
/*using UnityEngine;

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
   
}*/