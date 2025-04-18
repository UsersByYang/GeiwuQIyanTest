using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioProximityController : MonoBehaviour
{
    public AudioSource audioSource;
    public float maxDistance = 5f;
    public float minDistance = 1f;
    public Transform playerTransform;

    void Update()
    {
        if (playerTransform == null)
        {
            // 如果没有设置玩家的Transform，尝试获取场景中的玩家对象
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (playerTransform != null)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance <= maxDistance)
            {
                audioSource.enabled = true;
                // 根据距离计算音量
                float volume = Mathf.Clamp01(1 - (distance - minDistance) / (maxDistance - minDistance));
                audioSource.volume = volume;
            }
            else
            {
                audioSource.enabled = false;
            }
        }
    }
}
