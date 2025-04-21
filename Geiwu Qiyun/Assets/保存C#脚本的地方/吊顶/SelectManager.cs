/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    public Button correctButton;
    public Button wrongButton;
    public Animator animator;
    
    private Animator ApparatusAnimatior;
    public DialogueManager3 wrongDialogue;
    public DialogueManager3 correctDialogue;
    public DialogueManager3 startDialogue;

    private void Start()
    {
        ApparatusAnimatior = GetComponent<Animator>();
        correctButton.onClick.AddListener(CorrectButtonClicked);
        wrongButton.onClick.AddListener(WrongButtonClicked);
        startDialogue.StartDialogue();
    }

    private void CorrectButtonClicked()
    {
        // ѡ����ȷ�����Ŷ���
        correctDialogue.StartDialogue();
        animator.SetBool ("pull",true);
        
    }

    private void WrongButtonClicked()
    {
        // ѡ����󣬿�ʼ����Ի�
        wrongDialogue.StartDialogue();
        // �Ի�������������ʾ��ť��
        correctButton.gameObject.SetActive(true);
        wrongButton.gameObject.SetActive(true);
    }

   
}*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    public Button correctButton;
    public Button wrongButton;
    public Animator animator;

    private Animator ApparatusAnimatior;
    public DialogueManager3 wrongDialogue;
    public DialogueManager3 correctDialogue;
    public DialogueManager3 startDialogue;

    private void Start()
    {
        ApparatusAnimatior = GetComponent<Animator>();
        correctButton.onClick.AddListener(CorrectButtonClicked);
        wrongButton.onClick.AddListener(WrongButtonClicked);
        startDialogue.StartDialogue();
    }

    private void CorrectButtonClicked()
    {
        Debug.Log("��ȷ��ť�����");
        // ѡ����ȷ�����Ŷ���
        correctDialogue.StartDialogue();
        animator.SetBool("pull", true);
    }

    private void WrongButtonClicked()
    {
        Debug.Log("����ť�����");
        // ѡ����󣬿�ʼ����Ի�
        wrongDialogue.StartDialogue();
        // �Ի������߼����ƺ�������
        // correctButton.gameObject.SetActive(true);
        // wrongButton.gameObject.SetActive(true);
    }
}

