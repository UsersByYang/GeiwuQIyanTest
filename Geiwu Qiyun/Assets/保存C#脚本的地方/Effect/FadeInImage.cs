/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInImage : MonoBehaviour
{
    public float fadeDuration = 2f; 
    public  Image image;
    public DialogueManager2 dialogue1;
    public DialogueManager2 dialogue2;
    public  bool isFade=false;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        if (dialogue1.DialogueEnd)
        {
            float elapsedTime = 0f;
            while (elapsedTime < fadeDuration)
            {
                // 计算透明度，从0逐渐增加到1
                float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            // 确保最终透明度为1
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            isFade = true;
            if (isFade)
            {
                dialogue2.StartDialogue();
            }
        }
        
    }
}
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInImage : MonoBehaviour
{
    public float fadeDuration = 2f;
    public Image image;
    public DialogueManager2 dialogue1;
    public DialogueManagerAuto  dialogue2;
    public bool isFade = false;

    void Start()
    {
        // 确保图片初始透明度为0
        if (image != null)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        }

        // 开始检查对话是否结束，若结束则启动淡入协程
        StartCoroutine(CheckDialogueEnd());
    }

    private IEnumerator CheckDialogueEnd()
    {
        while (true)
        {
            if (dialogue1 != null && dialogue1.DialogueEnd)
            {
                StartCoroutine(FadeIn());
                yield break;
            }
            yield return null;
        }
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            // 计算透明度，从0逐渐增加到1
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // 确保最终透明度为1
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        isFade = true;
        if (isFade && dialogue2 != null)
        {
            dialogue2.StartDialogue();
            // 开始检查dialogue2是否结束
            StartCoroutine(CheckDialogue2End());
        }
    }

    private IEnumerator CheckDialogue2End()
    {
        while (true)
        {
            if (dialogue2 != null && dialogue2.DialogueEnd)
            {
                StartCoroutine(FadeOut());
                yield break;
            }
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            // 计算透明度，从1逐渐减小到0
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // 确保最终透明度为0
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }
}