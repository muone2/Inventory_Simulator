using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    [SerializeField] int boxSpaceCount = 5;
    [SerializeField] GameObject itemInfoTextPanel;
    [SerializeField] Text itemInfoText;
    [SerializeField] List<GameObject> ItemUI; //각 숫자에 서로 대응되고 있다?

    [SerializeField] List<ItemInfo> ListInInventory;




    [SerializeField] GameObject ItemUIPrefeb;

    public void GetItem(GameObject item)
    {
        if (item.GetComponent<ItemInfo>() != null)
        {
            int targetInventoryNum = CheckItemInInventory(item.GetComponent<ItemInfo>().GetItemNum());
            PutItemInInventory(targetInventoryNum, item); // 해당 칸에 해당 아이템 넣음
        }
    }

    public void Start()
    {
        ListInInventory.Clear();

        for (int i = 0; i < ItemUI.Count; i++)
            ItemUI[i].SetActive(false);

        for (int i = 0; i < boxSpaceCount; i++)
        {
            ListInInventory.Add(null); 
            ItemUI[i].SetActive(true);
        }
    }

    public void SetInventoryUI()
    {
        for (int i = 0; i < ListInInventory.Count; i++)
        {
            if (ListInInventory[i] != null)
                ItemUI[i].GetComponentInChildren<Text>().text =
                        ListInInventory[i].GetItemNum() + "번 item" + System.Environment.NewLine + System.Environment.NewLine + "   x" + ListInInventory[i].GetItemCount();
            else
                ItemUI[i].GetComponentInChildren<Text>().text = null;
        }
    }


    public void OpenInventoryInfoUI()
    {
        itemInfoTextPanel.SetActive(true);

        GameObject g = EventSystem.current.currentSelectedGameObject;
        int target = 0;
        for (int i = 0; i < ItemUI.Count; i++)
        {
            if (ItemUI[i] == g)
                target = i; //내가 누른 건 target번째 칸이다.
        }

        if (ListInInventory[target] == null)
            itemInfoText.text = null;
        else
            itemInfoText.text = "name : " + ListInInventory[target].GetItemNum() + System.Environment.NewLine +
                "Count : " + ListInInventory[target].GetItemCount();
    }

    public void CloseInventoryInfoUI()
    {
        itemInfoTextPanel.SetActive(false);
    }

    //  public void ShowInventoryItem(List<ItemInfo> itemlist)
    // {

    // }

    private int CheckItemInInventory(int num)
    {
        for (int i = 0; i < ListInInventory.Count; i++)
        {
            if(ListInInventory[i] != null && ListInInventory[i].GetItemNum() == num)
            {
                return i;
            }
        }
        //아이템이 가방에 없으면 빈 공간을 찾음
        return CheckInventoryNullNum();
    }

    private int CheckInventoryNullNum()
    {
        for (int i = 0; i < ListInInventory.Count; i++)
        {
            if (ListInInventory[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

    private void PutItemInInventory(int target, GameObject item)
    {
        if (target >= 0 && ListInInventory[target] != null)
        {
            ListInInventory[target].AddItemCount(item.GetComponent<ItemInfo>().GetItemCount()); //새로 들어온 아이템의 개수만큼 원래 있던 거에서 늘이기만 한다.
            Destroy(item);
        }
        else if (target >= 0 && ListInInventory[target] == null)
        {
            item.transform.parent = gameObject.transform;
            item.SetActive(false);
            ListInInventory[target] = item.GetComponent<ItemInfo>(); //주운 아이템의 정보가 빈 칸으로 들어간다.
        }
        else
            Debug.Log("가방에 빈칸이 없어요"); //가방이 꽉 차서 못 줍는다.
    }
}
