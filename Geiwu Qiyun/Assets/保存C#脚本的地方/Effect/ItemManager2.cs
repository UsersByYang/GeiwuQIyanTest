using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager2 : ItemManager
{
    void Start()
    {
        base.Start();
    }

    // ����Ƿ�������Ʒ�����ռ���ȥ���Ի�����߼�
    new private void CheckAllItemsCollected()
    {
        fadeandloadscene.Load();
    }

  
    
}