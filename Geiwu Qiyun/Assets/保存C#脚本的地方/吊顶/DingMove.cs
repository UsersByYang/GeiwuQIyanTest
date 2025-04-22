using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DingMove : MonoBehaviour
{
    public Animator animator;
    private bool isMoving;
    public bool isDropped;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isMoving = false;
        isDropped = true; // ��ʼ״̬����Ϊ����
        animator.SetBool("pull", false);
        animator.SetBool("down", true);
        animator.SetBool("move", false);
        animator.SetBool("start", true);
       
    }

    // Update is called once per frame
    void Update()
    {
        // ��������ͷ��²���
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("pull", true);
            animator.SetBool("down", false);
            isDropped = false;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("pull", false);
            animator.SetBool("down", true);
            isDropped = true;
        }

        // ���������ƶ�����
        if (!isDropped)
        {
            float moveInput = Input.GetAxis("Horizontal");
            if (moveInput != 0)
            {
                if (!isMoving)
                {
                    animator.SetBool("move", true);
                    animator.SetBool("pause", false);
                    isMoving = true;
                }

                // ��������ķ�������ƶ�
                transform.Translate(Vector3.right * moveInput * Time.deltaTime*3);
            }
            else
            {
                if (isMoving)
                {
                    animator.SetBool("move", false);
                    animator.SetBool("pause", true);
                    isMoving = false;
                }
            }
        }
        else
        {
            animator.SetBool("move", false);
            isMoving = false;
        }
    }
}
    

