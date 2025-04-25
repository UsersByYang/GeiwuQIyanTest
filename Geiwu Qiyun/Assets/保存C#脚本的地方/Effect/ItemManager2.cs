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

    // 检测是否所有物品均被收集，去除对话相关逻辑
    new private void CheckAllItemsCollected()
    {
        fadeandloadscene.Load();
    }

  
    
}