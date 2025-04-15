using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeAndLoadScene : MonoBehaviour
{
    public Image fadeImage; // ���ڵ��뵭����Image���
    public Button fadeButton; // ����İ�ť
    public string sceneToLoad; // Ҫ���صĳ�������

    private void Start()
    {
        // Ϊ��ť��ӵ���¼�
        fadeButton.onClick.AddListener(OnButtonClick);
        
    }

    private void OnButtonClick()
    {
        // ��ʼ���뵭��Э��
        StartCoroutine(FadeAndLoad());
    }

    private IEnumerator FadeAndLoad()
    {
        // ����Ч��
        float fadeDuration = 1f; // ����ʱ��
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f);

        // �����³���
        SceneManager.LoadScene(sceneToLoad);

    }
}
