using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target; // ���ǵ�Transform
    public float smoothing = 0.1f; // ����Ч��
    public Vector3 offset; // ƫ����

    void Start()
    {
        
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 5, -35);
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}

