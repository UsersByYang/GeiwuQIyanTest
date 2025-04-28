using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFadeDelay : MonoBehaviour
{
    public Image targetImage; // 要操作的图像组件
    public float delayBeforeFade = 3f; // 延迟开始淡入的时间
    public float fadeDuration = 2f; // 淡入持续时间

    void Start()
    {
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        // 等待开始淡入的时间
        yield return new WaitForSeconds(delayBeforeFade);

        // 开始淡入
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, 0);
    }
}