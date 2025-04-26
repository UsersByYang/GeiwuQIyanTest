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
                // ����͸���ȣ���0�����ӵ�1
                float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            // ȷ������͸����Ϊ1
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
        // ȷ��ͼƬ��ʼ͸����Ϊ0
        if (image != null)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        }

        // ��ʼ���Ի��Ƿ����������������������Э��
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
            // ����͸���ȣ���0�����ӵ�1
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // ȷ������͸����Ϊ1
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        isFade = true;
        if (isFade && dialogue2 != null)
        {
            dialogue2.StartDialogue();
            // ��ʼ���dialogue2�Ƿ����
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
            // ����͸���ȣ���1�𽥼�С��0
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // ȷ������͸����Ϊ0
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }
}