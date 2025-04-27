using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFade : MonoBehaviour
{
    
    public Light targetLight; // Ҫ�����ĵƹ�
    public float delayBeforeFade = 2f; // �ӳ�ʱ��
    public float fadeDuration = 3f; // �ƹ������ʱ��

    void Start()
    {
        // ��ʼЭ��
        StartCoroutine(FadeInLight());
    }

    private IEnumerator FadeInLight()
    {
        // �ȴ��ӳ�ʱ��
        yield return new WaitForSeconds(delayBeforeFade);

        float elapsedTime = 0f;
        float startIntensity = targetLight.intensity;
        float endIntensity = 5f; // ������������Ϊ1���ɰ������

        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            targetLight.intensity = Mathf.Lerp(startIntensity, endIntensity, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // ȷ�����մﵽĿ������
        targetLight.intensity = endIntensity;
    }
}

