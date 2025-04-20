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
        originalPosition = rectTransform.anchoredPosition; // 保存原始位置
        puzzleManager = FindObjectOfType<PuzzleManager>(); // 获取 PuzzleManager 实例
    }

    public void Initialize(int x, int y)
    {
        x_index = x;
        y_index = y;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 开始拖动时的处理
        if (IsInCorrectPosition())
        {
            puzzleManager.num--;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 拖动时更新位置
        rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 拖动结束时的处理
        if (IsInCorrectPosition())
        {
            // 如果放在正确位置，固定在该位置
            rectTransform.anchoredPosition = puzzleManager.GetCorrectPosition(x_index, y_index);
            puzzleManager.num++;
        }
        else
        {
            // 如果没有放在正确位置，返回原始位置
            rectTransform.anchoredPosition = originalPosition;
        }
        // rectTransform.anchoredPosition = originalPosition;

        JugeEnd();
    }

    private void JugeEnd()
    {
        if (puzzleManager.num >= puzzleManager.rows * puzzleManager.columns)
        {
            Debug.Log("---------游戏结束--------------");
        }
    }

    private bool IsInCorrectPosition()
    {
        //正确位置和当前位置的差值
        bool isMatch = Mathf.Abs(rectTransform.anchoredPosition.x - puzzleManager.GetCorrectPosition(x_index, y_index).x) < 100f&& Mathf.Abs(rectTransform.anchoredPosition.y - puzzleManager.GetCorrectPosition(x_index, y_index).y) < 100f;
        return isMatch;
    }
}
