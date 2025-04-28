using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    public bool isItemPicked=false;

    private void Start()
    {
        MapItemManager.Instance.RegisterItem(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
                // ȷ��Instance��Ϊnull
                if (MapItemManager.Instance != null)
                {
                    MapItemManager.Instance.RemoveItem(this);
                }
                else
                {
                    Debug.LogError("MapItemManager.Instance is null!");
                }

                AddNewItem();

           // MapItemManager.Instance.RemoveItem(this);//

            Destroy(gameObject);
            isItemPicked = true;
            //ItemManager.Instance.OnItemCollected(); // ֪ͨ��������Ʒ���ռ�
        }
    }

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            playerInventory.itemList.Add(thisItem);
            //InventoryManager.CreatNewItem(thisItem);
        }
        else
        {
            thisItem.itemHeld += 1;
        }
        InventoryManager.RefreshItem();
    }
}
