using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInEffect : MonoBehaviour
{
    //������ڳ�����ʼ
    public Image fadeImage; // ��ɫͼ��
    public float fadeDuration = 2f; // �������ʱ��
    private Color startColor;
    private Color endColor = Color.clear;

    void Start()
    {
        startColor = fadeImage.color;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            fadeImage.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = endColor;
       
         Destroy(fadeImage.gameObject);
    }
}