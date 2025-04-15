using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMove : MonoBehaviour
{
    public float pushForceThreshold = 5f;
    private Animator animator;
    private bool isColliding;
    private float returnToIdleDelay = 5f; // �ӳٻص�idle������ʱ�䣬��λ��

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on this object.");
            return;
        }
        animator.Play("idle");
        isColliding = false;
    }

    float GetRelativeVelocityMagnitude(Collision collision)
    {
        return collision.relativeVelocity.magnitude;
    }

    void OnCollisionEnter(Collision collision)
    {
        float velocityMagnitude = GetRelativeVelocityMagnitude(collision);
        if (velocityMagnitude > pushForceThreshold)
        {
            animator.Play("rollingStone");
            isColliding = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        isColliding = false;
        // �ӳٵ��ûص�idle�����ĺ���
        Invoke("ReturnToIdle", returnToIdleDelay);
    }

    void ReturnToIdle()
    {
        if (!isColliding)
        {
            animator.Play("idle");
        }
    }
}


