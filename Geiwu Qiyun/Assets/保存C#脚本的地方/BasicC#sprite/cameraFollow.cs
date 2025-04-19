using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target; // 主角的Transform
    public float smoothing = 0.1f; // 过渡效果
    public Vector3 offset; // 偏移量

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

