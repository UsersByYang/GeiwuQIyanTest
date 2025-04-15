using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInEffect : MonoBehaviour
{
    //这个用于场景开始
    public Image fadeImage; // 黑色图像
    public float fadeDuration = 2f; // 淡入持续时间
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