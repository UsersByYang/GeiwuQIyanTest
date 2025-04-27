using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager2 : PuzzleManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void RecordRightPos(int posindexX, int posindexY)
    {
        Vector2 anchorePosition = targetImage.GetComponent<RectTransform>().anchoredPosition;
        float x1 = (float)(anchorePosition.x - 1593.75 / 25);
        float y1 = (float)(anchorePosition.y - 1593.75 / 25);
        Vector2 targetpos = new Vector2(x1, y1);
        float x2 = (float)(targetpos.x + posindexX * 1593.75 / 25);
        float y2 = (float)(targetpos.y + posindexY * 1593.75 / 25);
        rightPos[posindexX, posindexY] = new Vector3(x2, y2, 0);
    }
}
