using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeAndLoadScene2 : MonoBehaviour
{
    public Image fadeImage;
    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void Load()
    {
        StartCoroutine(FadeAndLoad());
    }
    public  IEnumerator FadeAndLoad()
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
