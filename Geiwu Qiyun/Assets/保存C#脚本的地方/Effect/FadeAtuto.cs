using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeAtuto : MonoBehaviour
{
    public Image fadeImage; // 用于实现淡出效果的Image组件
    public float fadeDuration = 2f; // 淡出持续时间
    public float delayBeforeFade = 3f; // 延迟开始淡出的时间
    public string targetSceneName; // 要跳转的目标场景名称

    private void Start()
    {
        // 延迟调用FadeAndLoad方法
        Invoke("FadeAndLoad", delayBeforeFade);
    }

    private void FadeAndLoad()
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

        // 加载目标场景
        SceneManager.LoadScene(targetSceneName);
    }
}