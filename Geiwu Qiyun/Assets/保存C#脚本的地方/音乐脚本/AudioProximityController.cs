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
            // ���û��������ҵ�Transform�����Ի�ȡ�����е���Ҷ���
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (playerTransform != null)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance <= maxDistance)
            {
                audioSource.enabled = true;
                // ���ݾ����������
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
