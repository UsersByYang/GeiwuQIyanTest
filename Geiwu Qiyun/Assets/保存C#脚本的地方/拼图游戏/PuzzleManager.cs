using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public GameObject targetImage;
    public Texture2D originalImage; // 原始图片
    public int rows = 3; // 行数
    public int columns = 3; // 列数
    public GameObject puzzlePiecePrefab; // 拼图块预制体
    public Vector3[,] rightPos;
    public int num;//当前已经完成的数量
    // Start is called before the first frame update
    void Start()
    {
        // 将原始的大图，分割为几张小图
        rightPos = new Vector3[rows, columns];
        CreatePuzzle();
    }

    void CreatePuzzle()
    {
        int pieceWidth = originalImage.width / columns;
        int pieceHeight = originalImage.height / rows;
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                //分别从原始的大图上，获取各个小图需要的部分像素
                Texture2D piece = new Texture2D(pieceWidth, pieceHeight);
                piece.SetPixels(originalImage.GetPixels(x * pieceWidth, y * pieceHeight, pieceWidth, pieceHeight));
                piece.Apply();
                //生成新的小图的prefab,赋值各部分的像素，设置初始位置
                GameObject puzzlePiece = Instantiate(puzzlePiecePrefab, this.transform);
                puzzlePiece.name = $"Piece_{x}_{y}";
                puzzlePiece.GetComponent<Image>().sprite = Sprite.Create(piece, new Rect(0, 0, pieceWidth, pieceHeight), new Vector2(0.5f, 0.5f));
                puzzlePiece.GetComponent<PuzzlePiece>().Initialize(x, y);
                puzzlePiece.GetComponent<RectTransform>().anchoredPosition =
                    new Vector2(Random.Range(0f, 250f), Random.Range(0f, 250f));
                RecordRightPos(x, y);
                //puzzlePiece.GetComponent<RectTransform>().anchoredPosition = rightPos[x, y];
            }
        }

    }

    // void RecordRightPos(int posindexX, int posindexY)
    // {
    //     //记录正确的位置
    //     RectTransform rectTransform = targetImage.GetComponent<RectTransform>();
    //     Vector2 anchoredPosition = rectTransform.anchoredPosition;
    //     float pieceWidth = rectTransform.rect.width / columns;
    //     float pieceHeight = rectTransform.rect.height / rows;
    //     Vector2 targetPos = new Vector2(anchoredPosition.x - pieceWidth,
    //         anchoredPosition.y - pieceHeight);
    //     rightPos[posindexX,posindexY] = new Vector3(
    //         targetPos.x + posindexX * (pieceWidth / columns),
    //         targetPos.y + posindexY * (pieceHeight / rows), 0);
    // }

    void RecordRightPos(int posindexX, int posindexY)
    {
        //RectTransform rectTransform = targetImage.GetComponent<RectTransform>();
        // float pieceWidth = rectTransform.rect.width / columns;
        // float pieceHeight = rectTransform.rect.height / rows;
        Vector2 anchorePosition = targetImage.GetComponent<RectTransform>().anchoredPosition;
        float x1 = (float)(anchorePosition.x - 417 / 2.5);
        float y1 = (float)(anchorePosition.y - 530 / 2.5);
        Vector2 targetpos = new Vector2(x1, y1);
        float x2 =(float)( targetpos.x + posindexX * 417 / 2.5);
        float y2 = (float)(targetpos.y + posindexY * 530 / 2.5);
        rightPos[posindexX, posindexY] = new Vector3(x2 ,y2 , 0);
        // 获取原图的实际位置
       // Vector2 anchoredPosition = rectTransform.anchoredPosition;
        // 计算目标位置，考虑原图的实际位置
        //rightPos[posindexX, posindexY] = new Vector3(anchoredPosition.x + (posindexX * pieceWidth) - (rectTransform.rect.width / 2) + (pieceWidth / 2), anchoredPosition.y + (posindexY * pieceHeight) - (rectTransform.rect.height / 2) + (pieceHeight / 2), 0);

    }

    public Vector3 GetCorrectPosition(int posindexX, int posindexY)
    {

        return rightPos[posindexX, posindexY];
    }


    // Update is called once per frame
    void Update()
    {

    }
}
