using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Animations;

public class FadeInEffect : MonoBehaviour
{
    //这个用于场景开始
    public Image fadeImage; // 黑色图像
    public float fadeDuration = 2f; // 淡入持续时间
    private Color startColor;
    private Color endColor = Color.clear;

    // 新增：动画所在的游戏对象
    //public GameObject animatedObject;
    //private Animator animator;

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

        // 淡入完成后播放动画
        //animator.enabled = true;
        //animator.Play("开场动画");
    }
}