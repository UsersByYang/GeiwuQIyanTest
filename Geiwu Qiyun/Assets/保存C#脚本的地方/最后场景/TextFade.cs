using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TextFade: MonoBehaviour
{
    public TMP_Text targetText; // 要操作的文本组件
    public float fadeInDuration = 2f; // 淡入持续时间
    public float stayDuration = 3f;  // 完全显现后停留的持续时间
    public float fadeOutDuration = 2f; // 淡出持续时间

    void Start()
    {
        targetText.color = new Color(targetText.color.r, targetText.color.g, targetText.color.b, 0);
        StartCoroutine(FadeTextInAndOut());
    }

    IEnumerator FadeTextInAndOut()
    {
        // 等待开始淡入的时间
        yield return new WaitForSeconds(2f);

        // 淡入文本
        float elapsedFadeInTime = 0f;
        while (elapsedFadeInTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0, 1, elapsedFadeInTime / fadeInDuration);
            targetText.color = new Color(targetText.color.r, targetText.color.g, targetText.color.b, alpha);
            elapsedFadeInTime += Time.deltaTime;
            yield return null;
        }
        targetText.color = new Color(targetText.color.r, targetText.color.g, targetText.color.b, 1);

        // 等待完全显现的时间
        yield return new WaitForSeconds(stayDuration);

        // 淡出文本
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