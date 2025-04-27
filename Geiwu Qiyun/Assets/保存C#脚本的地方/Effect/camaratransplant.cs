using UnityEngine;
using System.Collections;

public class CameraTransitionToTarget : MonoBehaviour
{
    public Transform target; // Ŀ�������Transform
    public float moveDuration = 3f; // ����ƶ���Ŀ�������ʱ��
    public float zoomDuration = 2f; // ����Ŵ��ʱ��
    public float targetZoom = 20f; // �Ŵ���Ŀ����Ұ�Ƕ�
    public Vector3 offset; // ����ƫ���������ڵ����������λ��

    private Transform playerTransform;
    private Camera mainCamera;

    void Start()
    {
        playerTransform = transform; // ��ǰ���������ң����Ե�ǰ�����Transform������ҵ�Transform
        mainCamera = GetComponent<Camera>();
        StartCoroutine(MoveAndZoom());
    }

    private IEnumerator MoveAndZoom()
    {
        float elapsedMoveTime = 0f;
        Vector3 startPosition = playerTransform.position;
        Quaternion startRotation = playerTransform.rotation;

        while (elapsedMoveTime < moveDuration)
        {
            float t = elapsedMoveTime / moveDuration;
            // �������ƫ������Ŀ��λ��
            Vector3 targetPositionWithOffset = target.position + offset;
            transform.position = Vector3.Lerp(startPosition, targetPositionWithOffset, t);
            transform.rotation = Quaternion.Lerp(startRotation, target.rotation, t);
            elapsedMoveTime += Time.deltaTime;
            yield return null;
        }
        // ���ս����λ������Ϊ����ƫ������Ŀ��λ��
        transform.position = target.position + offset;
        transform.rotation = target.rotation;

        float elapsedZoomTime = 0f;
        float startZoom = mainCamera.fieldOfView;

        while (elapsedZoomTime < zoomDuration)
        {
            float t = elapsedZoomTime / zoomDuration;
            mainCamera.fieldOfView = Mathf.Lerp(startZoom, targetZoom, t);
            elapsedZoomTime += Time.deltaTime;
            yield return null;
        }
        mainCamera.fieldOfView = targetZoom;
    }
}