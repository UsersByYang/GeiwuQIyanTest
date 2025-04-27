using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFade : MonoBehaviour
{
    
    public Light targetLight; // 要变亮的灯光
    public float delayBeforeFade = 2f; // 延迟时间
    public float fadeDuration = 3f; // 灯光变亮的时间

    void Start()
    {
        // 开始协程
        StartCoroutine(FadeInLight());
    }

    private IEnumerator FadeInLight()
    {
        // 等待延迟时间
        yield return new WaitForSeconds(delayBeforeFade);

        float elapsedTime = 0f;
        float startIntensity = targetLight.intensity;
        float endIntensity = 5f; // 假设最终亮度为1，可按需调整

        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            targetLight.intensity = Mathf.Lerp(startIntensity, endIntensity, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // 确保最终达到目标亮度
        targetLight.intensity = endIntensity;
    }
}

