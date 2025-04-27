using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoadAuto : MonoBehaviour
{
    public string targetSceneName; // 目标场景名称
    public float delayBeforeTransition = 3f; // 延迟时间
    public float fadeDuration = 2f; // 淡出时间
    public Image fadeImage; // 公有图片引用

    void Start()
    {
        fadeImage.color = Color.clear;
        StartCoroutine(TransitionToScene());
    }

    private IEnumerator TransitionToScene()
    {
        yield return new WaitForSeconds(delayBeforeTransition);

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            fadeImage.color = Color.Lerp(Color.clear, Color.black, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = Color.black;

        SceneManager.LoadScene(targetSceneName);
    }
}