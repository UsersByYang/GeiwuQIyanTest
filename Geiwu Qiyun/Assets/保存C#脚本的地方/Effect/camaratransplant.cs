using UnityEngine;
using System.Collections;

public class CameraTransitionToTarget : MonoBehaviour
{
    public Transform target; // 目标物体的Transform
    public float moveDuration = 3f; // 相机移动到目标物体的时间
    public float zoomDuration = 2f; // 相机放大的时间
    public float targetZoom = 20f; // 放大后的目标视野角度
    public Vector3 offset; // 公有偏移量，用于调整相机最终位置

    private Transform playerTransform;
    private Camera mainCamera;

    void Start()
    {
        playerTransform = transform; // 当前相机对着玩家，所以当前相机的Transform就是玩家的Transform
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
            // 计算带有偏移量的目标位置
            Vector3 targetPositionWithOffset = target.position + offset;
            transform.position = Vector3.Lerp(startPosition, targetPositionWithOffset, t);
            transform.rotation = Quaternion.Lerp(startRotation, target.rotation, t);
            elapsedMoveTime += Time.deltaTime;
            yield return null;
        }
        // 最终将相机位置设置为带有偏移量的目标位置
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