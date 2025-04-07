using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class playermovement : MonoBehaviour
{
    private Animator ani;
    private Rigidbody rBody;

    void Start()
    {
        ani = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ȷ������ƽ����Y���ƶ���ֻ��X��Z����λ��
        Vector3 dir = new Vector3(horizontalInput, 0f, verticalInput);
        ani.SetFloat("Horizontal", horizontalInput);
        ani.SetFloat("Vertical", verticalInput);
        ani.SetFloat("Speed", dir.magnitude);

        rBody.velocity = dir * 5.0f;
    }
}

