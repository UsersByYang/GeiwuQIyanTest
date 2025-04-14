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

    // Э�̷�����ʵ�ֵ���Ч����������һ������
    IEnumerator FadeOutAndLoadScene()
    {
        // ��¼�Ѿ���ȥ��ʱ�䣬��ʼΪ0
        float elapsedTime = 0f;
        // ������ͼ�����ɫ����Ϊ��ʼ��ɫ��͸����
        fadeImage.color = startColor;

        // ����ȥ��ʱ��С�ڵ������ʱ��ʱ������ִ�е������
        while (elapsedTime < fadeDuration)
        {
            // ����ʱ�����ţ��ڳ�ʼ��ɫ�ͽ�����ɫ֮��������Բ�ֵ���õ���ǰ֡����ɫ
            fadeImage.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            // �����Ѿ���ȥ��ʱ�䣬Time.deltaTime��ʾ����һ֡����ǰ֡��������ʱ��
            elapsedTime += Time.deltaTime;
            // ��ͣ��ǰЭ�̣��ȴ���һ֡�ټ���ִ��
            yield return null;
        }

        // ������ʱ���������ͼ����ɫ����Ϊ������ɫ����ɫ��
        fadeImage.color = endColor;
        // ʹ��SceneManager����ָ�����Ƶ���һ������
        SceneManager.LoadScene(nextSceneName);
    }
}
