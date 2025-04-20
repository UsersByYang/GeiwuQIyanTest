using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioProximityController : MonoBehaviour
{
    [Header("3D Sound Settings")]
    [SerializeField][Range(0f, 1f)] private float spatialBlend = 1f;
    [SerializeField] private AudioRolloffMode rolloffMode = AudioRolloffMode.Linear;
    [SerializeField] private float minDistance = 3f;
    [SerializeField] private float maxDistance = 20f;

    [Header("Player Reference")]
    [SerializeField] private Transform playerTransform;

    private AudioSource _audioSource;
    private float _baseVolume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        Configure3DSoundSettings();
        _baseVolume = _audioSource.volume;
    }

    private void Start()
    {
        InitializePlayerReference();
        ValidateDistanceSettings();
    }

    private void Update()
    {
        if (playerTransform == null) return;

        UpdateAudioBasedOnDistance();
        UpdateSpatialization();
    }

    private void Configure3DSoundSettings()
    {
        _audioSource.spatialize = true;
        _audioSource.spatialBlend = spatialBlend;
        _audioSource.rolloffMode = rolloffMode;
        _audioSource.minDistance = minDistance;
        _audioSource.maxDistance = maxDistance;
    }

    private void InitializePlayerReference()
    {
        if (playerTransform != null) return;

        var playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player reference missing!", this);
            enabled = false;
        }
    }

    private void ValidateDistanceSettings()
    {
        if (minDistance >= maxDistance)
        {
            Debug.LogWarning("Invalid distance settings! Swapping values.", this);
            (minDistance, maxDistance) = (maxDistance, minDistance);
        }
    }

    private void UpdateAudioBasedOnDistance()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= maxDistance)
        {
            HandleInRangeBehavior(distance);
        }
        else
        {
            HandleOutOfRangeBehavior();
        }
    }

    private void HandleInRangeBehavior(float distance)
    {
        // ʹ�ö���˥���������˶���֪
        float volume = CalculateLogarithmicVolume(distance);
        _audioSource.volume = Mathf.Clamp(volume, 0f, _baseVolume);

        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    private float CalculateLogarithmicVolume(float distance)
    {
        float normalizedDistance = Mathf.Clamp01((distance - minDistance) / (maxDistance - minDistance));
        return _baseVolume * (1f - Mathf.Log10(normalizedDistance * 9f + 1f));
    }

    private void HandleOutOfRangeBehavior()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }

    private void UpdateSpatialization()
    {
        // ������ҳ����Ż��ռ���Ч
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        float angle = Vector3.Angle(playerTransform.forward, directionToPlayer);

        // ����ұ�����Դʱ��������
        float directionalAttenuation = Mathf.Clamp01(1 - angle / 180f);
        _audioSource.volume *= directionalAttenuation;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, minDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}