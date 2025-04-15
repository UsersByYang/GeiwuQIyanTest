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

    //���ڽ�ɫ�ƶ�
    public float speed = 10;


    //����ʰȡ��Ʒ
    public GameObject myBag;
    bool isOpen;

    //������ʯͷ��ʯͷ��������
    //��ɫ�Ӵ�ʯͷ�Ұ�ס�����������ʯͷ����������ĳ��ʱ���ʯͷ�ƶ���ֹͣ��ʯͷ����������ʯͷ��������
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

        // �ж��෴���Ƿ�ͬʱ����
        bool oppositeX = (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D));
        bool oppositeZ = (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S));

        if (oppositeX || oppositeZ)
        {
            // ����෴��ͬʱ���£�ֹͣ�ƶ�
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
    //��ת
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
            // �����ˮƽ��ֱ���������
            if (horizontalInput != 0 || verticalInput != 0)
            {
                // ���ý�ɫAnimator��IsPushing����Ϊtrue���Բ�����ʯͷ����
                playerAnimation.SetBool("IsPushing", true);

                // ���ӿ�ʼ��ʯͷ�����ڵ�ʱ���Ƿ�ﵽ���趨����ʯͷ����ʱ��
                if (Time.time - pushStartTime >= pushDuration)
                {
                    // ֹͣ��ʯͷ״̬
                    isPushing = false;
                    // ���ý�ɫAnimator��IsPushing����Ϊfalse��ֹͣ������ʯͷ����
                    playerAnimation.SetBool("IsPushing", false);
                    // ����ʯͷAnimator��IsRolling����Ϊtrue���Բ���ʯͷ��������
                    stoneAnimation.SetBool("IsRolling", true);

                    // �����ʾ����ʯͷ�ؽ�ɫǰ���ƶ���ͨ����ȡ��ɫ��ǰ������
                    Vector3 moveDirection = transform.forward;
                    // ��ʯͷ�ĸ������һ����ǰ�ĳ�����ʹ���ƶ�
                    Stone.GetComponent<Rigidbody>().AddForce(moveDirection * 5f, ForceMode.Impulse);
                }
            }
            else
            {
                // ���û��ˮƽ��ֱ��������룬���ý�ɫAnimator��IsPushing����Ϊfalse��ֹͣ������ʯͷ����
                playerAnimation.SetBool("IsPushing", false);
            }
        }
    }*/
    //���ʯͷ
   /* void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Stone)
        {
            isPushing = true;
            pushStartTime = Time.time;
        }
    }*/
}
    

//ԭ����
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
    //��ת
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