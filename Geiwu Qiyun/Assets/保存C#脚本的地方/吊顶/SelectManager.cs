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
        // 选择正确，播放动画
        correctDialogue.StartDialogue();
        animator.SetBool ("pull",true);
        
    }

    private void WrongButtonClicked()
    {
        // 选择错误，开始错误对话
        wrongDialogue.StartDialogue();
        // 对话结束后重新显示按钮，
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
        Debug.Log("正确按钮被点击");
        // 选择正确，播放动画
        correctDialogue.StartDialogue();
        animator.SetBool("pull", true);
    }

    private void WrongButtonClicked()
    {
        Debug.Log("错误按钮被点击");
        // 选择错误，开始错误对话
        wrongDialogue.StartDialogue();
        // 对话结束逻辑完善后再启用
        // correctButton.gameObject.SetActive(true);
        // wrongButton.gameObject.SetActive(true);
    }
}

