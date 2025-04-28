using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using System.Collections;

public class AnimationFadeScene : MonoBehaviour
{
    public Animator animator;
    public Image fadeImage;
    public float fadeDuration = 2f;
    public string targetSceneName;

    // 用于接收动画事件调用的方法
    public void OnAnimationEnd()
    {
        StartCoroutine(FadeScene());
    }

    private IEnumerator FadeScene()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);

        SceneManager.LoadScene(targetSceneName);
    }
}