using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItemManager : MonoBehaviour
{
    public static MapItemManager Instance;
    private List<ItemOnWorld> mapItems = new List<ItemOnWorld>();
    public GameObject objectToShow;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void RegisterItem(ItemOnWorld item)
    {
        mapItems.Add(item);
    }

    public void RemoveItem(ItemOnWorld item)
    {
        mapItems.Remove(item);
        CheckAllItemsRemoved();
    }

    private void CheckAllItemsRemoved()
    {
        if (mapItems.Count == 0)
        {
            objectToShow.SetActive(true);
        }
    }
}
