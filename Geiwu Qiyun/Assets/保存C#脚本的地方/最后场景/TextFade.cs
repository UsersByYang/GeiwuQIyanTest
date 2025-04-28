using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextFade: MonoBehaviour
{
    public TMP_Text targetText; // Ҫ�������ı����
    public float fadeInDuration = 2f; // �������ʱ��
    public float stayDuration = 3f;  // ��ȫ���ֺ�ͣ���ĳ���ʱ��
    public float fadeOutDuration = 2f; // ��������ʱ��

    void Start()
    {
        targetText.color = new Color(targetText.color.r, targetText.color.g, targetText.color.b, 0);
        StartCoroutine(FadeTextInAndOut());
    }

    IEnumerator FadeTextInAndOut()
    {
        // �ȴ���ʼ�����ʱ��
        yield return new WaitForSeconds(2f);

        // �����ı�
        float elapsedFadeInTime = 0f;
        while (elapsedFadeInTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0, 1, elapsedFadeInTime / fadeInDuration);
            targetText.color = new Color(targetText.color.r, targetText.color.g, targetText.color.b, alpha);
            elapsedFadeInTime += Time.deltaTime;
            yield return null;
        }
        targetText.color = new Color(targetText.color.r, targetText.color.g, targetText.color.b, 1);

        // �ȴ���ȫ���ֵ�ʱ��
        yield return new WaitForSeconds(stayDuration);

        // �����ı�
        float elapsedFadeOutTime = 0f;
        while (elapsedFadeOutTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedFadeOutTime / fadeOutDuration);
            targetText.color = new Color(targetText.color.r, targetText.color.g, targetText.color.b, alpha);
            elapsedFadeOutTime += Time.deltaTime;
            yield return null;
        }
        targetText.color = new Color(targetText.color.r, targetText.color.g, targetText.color.b, 0);
    }
}