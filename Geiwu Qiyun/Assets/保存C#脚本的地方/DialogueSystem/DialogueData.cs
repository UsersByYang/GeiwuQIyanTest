using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;
    public string dialogueText;
    public Sprite characterSprite;//ͷ��
}

[System.Serializable]
public class Dialogue
{
    public DialogueLine[] lines;
}
