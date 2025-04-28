using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeAtuto : MonoBehaviour
{
    public Image fadeImage; // ����ʵ�ֵ���Ч����Image���
    public float fadeDuration = 2f; // ��������ʱ��
    public float delayBeforeFade = 3f; // �ӳٿ�ʼ������ʱ��
    public string targetSceneName; // Ҫ��ת��Ŀ�곡������

    private void Start()
    {
        // �ӳٵ���FadeAndLoad����
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

        // ����Ŀ�곡��
        SceneManager.LoadScene(targetSceneName);
    }
}