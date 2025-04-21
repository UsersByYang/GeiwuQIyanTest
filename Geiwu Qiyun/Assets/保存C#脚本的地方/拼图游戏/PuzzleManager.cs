using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public GameObject targetImage;
    public Texture2D originalImage; // ԭʼͼƬ
    public int rows = 3; // ����
    public int columns = 3; // ����
    public GameObject puzzlePiecePrefab; // ƴͼ��Ԥ����
    public Vector3[,] rightPos;
    public int num;//��ǰ�Ѿ���ɵ�����
    // Start is called before the first frame update
    void Start()
    {
        // ��ԭʼ�Ĵ�ͼ���ָ�Ϊ����Сͼ
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
                //�ֱ��ԭʼ�Ĵ�ͼ�ϣ���ȡ����Сͼ��Ҫ�Ĳ�������
                Texture2D piece = new Texture2D(pieceWidth, pieceHeight);
                piece.SetPixels(originalImage.GetPixels(x * pieceWidth, y * pieceHeight, pieceWidth, pieceHeight));
                piece.Apply();
                //�����µ�Сͼ��prefab,��ֵ�����ֵ����أ����ó�ʼλ��
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
    //     //��¼��ȷ��λ��
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
        // ��ȡԭͼ��ʵ��λ��
       // Vector2 anchoredPosition = rectTransform.anchoredPosition;
        // ����Ŀ��λ�ã�����ԭͼ��ʵ��λ��
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
