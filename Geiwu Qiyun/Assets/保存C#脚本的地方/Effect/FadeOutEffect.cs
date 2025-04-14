using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeOutEffect: MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 2f;
    public string nextSceneName;
    private Color startColor = Color.clear;
    private Color endColor = Color.black;

  
    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        StartCoroutine(FadeOutAndLoadScene());
    }

    // 协程方法，实现淡出效果并加载下一个场景
    IEnumerator FadeOutAndLoadScene()
    {
        // 记录已经过去的时间，初始为0
        float elapsedTime = 0f;
        // 将淡入图像的颜色设置为初始颜色（透明）
        fadeImage.color = startColor;

        // 当过去的时间小于淡入持续时间时，持续执行淡入操作
        while (elapsedTime < fadeDuration)
        {
            // 根据时间流逝，在初始颜色和结束颜色之间进行线性插值，得到当前帧的颜色
            fadeImage.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            // 增加已经过去的时间，Time.deltaTime表示从上一帧到当前帧所经过的时间
            elapsedTime += Time.deltaTime;
            // 暂停当前协程，等待下一帧再继续执行
            yield return null;
        }

        // 当淡入时间结束，将图像颜色设置为结束颜色（黑色）
        fadeImage.color = endColor;
        // 使用SceneManager加载指定名称的下一个场景
        SceneManager.LoadScene(nextSceneName);
    }
}
