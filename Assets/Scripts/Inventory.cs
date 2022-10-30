using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<ItemInfo> ListInInventory = new List<ItemInfo>(); //40칸 미리 만들어서 시작하자. 일단 거의 null이겠지만.
    [SerializeField] List<int> Count = new List<int>();

    public void GetItem(GameObject item)
    {
        if (item.GetComponent<ItemInfo>() != null)
        {
            int targetInventoryNum = CheckItemInInventory(item.GetComponent<ItemInfo>().GetItemNum());
            PutItemInInventory(targetInventoryNum, item); // 해당 칸에 해당 아이템 넣음
        }
    }

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
