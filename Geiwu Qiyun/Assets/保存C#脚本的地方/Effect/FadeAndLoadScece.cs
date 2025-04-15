using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeAndLoadScene : MonoBehaviour
{
    public Image fadeImage; // 用于淡入淡出的Image组件
    public Button fadeButton; // 点击的按钮
    public string sceneToLoad; // 要加载的场景名称

    private void Start()
    {
        // 为按钮添加点击事件
        fadeButton.onClick.AddListener(OnButtonClick);
        
    }

    private void OnButtonClick()
    {
        // 开始淡入淡出协程
        StartCoroutine(FadeAndLoad());
    }

    private IEnumerator FadeAndLoad()
    {
        // 淡入效果
        float fadeDuration = 1f; // 淡入时间
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f);

        // 加载新场景
        SceneManager.LoadScene(sceneToLoad);

    }
}
