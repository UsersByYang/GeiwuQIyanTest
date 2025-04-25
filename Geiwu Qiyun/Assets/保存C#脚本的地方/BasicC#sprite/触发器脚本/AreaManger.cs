using System.Collections;
using System.Collections.Generic;
// AreaManager.cs
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public static AreaManager Instance;

    [Header("Settings")]
    public GameObject hiddenObject; // 需要最后显示的物体
    private int completedAreas;

    private void Awake()
    {
        Instance = this;
        if (hiddenObject != null)
            hiddenObject.SetActive(false);
    }

    public void RegisterAreaCompletion()
    {
        completedAreas++;
        CheckCompletion();
    }

    private void CheckCompletion()
    {
        if (completedAreas >= 4)
        {
            if (hiddenObject != null)
                hiddenObject.SetActive(true);
        }
    }
}

