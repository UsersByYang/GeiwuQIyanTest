using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
    public Button correctButton;
    public Button wrongButton;
    public Animator animator;
    
    private Animator ApparatusAnimatior;
    public DialogueManager wrongDialogue;
    public DialogueManager correctDialogue;
    public DialogueManager startDialogue;

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

   
}

