using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int x_index;
    public int y_index;
    private RectTransform rectTransform;
    private Vector3 originalPosition;
    private PuzzleManager puzzleManager;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition; // ����ԭʼλ��
        puzzleManager = FindObjectOfType<PuzzleManager>(); // ��ȡ PuzzleManager ʵ��
    }

    public void Initialize(int x, int y)
    {
        x_index = x;
        y_index = y;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // ��ʼ�϶�ʱ�Ĵ���
        if (IsInCorrectPosition())
        {
            puzzleManager.num--;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // �϶�ʱ����λ��
        rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �϶�����ʱ�Ĵ���
        if (IsInCorrectPosition())
        {
            // ���������ȷλ�ã��̶��ڸ�λ��
            rectTransform.anchoredPosition = puzzleManager.GetCorrectPosition(x_index, y_index);
            puzzleManager.num++;
        }
        else
        {
            // ���û�з�����ȷλ�ã�����ԭʼλ��
            rectTransform.anchoredPosition = originalPosition;
        }
        // rectTransform.anchoredPosition = originalPosition;

        JugeEnd();
    }

    private void JugeEnd()
    {
        if (puzzleManager.num >= puzzleManager.rows * puzzleManager.columns)
        {
            Debug.Log("---------��Ϸ����--------------");
        }
    }

    private bool IsInCorrectPosition()
    {
        //��ȷλ�ú͵�ǰλ�õĲ�ֵ
        bool isMatch = Mathf.Abs(rectTransform.anchoredPosition.x - puzzleManager.GetCorrectPosition(x_index, y_index).x) < 100f&& Mathf.Abs(rectTransform.anchoredPosition.y - puzzleManager.GetCorrectPosition(x_index, y_index).y) < 100f;
        return isMatch;
    }
}
