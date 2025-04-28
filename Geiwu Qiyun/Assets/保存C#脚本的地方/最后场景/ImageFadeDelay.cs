using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFadeDelay : MonoBehaviour
{
    public Image targetImage; // Ҫ������ͼ�����
    public float delayBeforeFade = 3f; // �ӳٿ�ʼ�����ʱ��
    public float fadeDuration = 2f; // �������ʱ��

    void Start()
    {
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        // �ȴ���ʼ�����ʱ��
        yield return new WaitForSeconds(delayBeforeFade);

        // ��ʼ����
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