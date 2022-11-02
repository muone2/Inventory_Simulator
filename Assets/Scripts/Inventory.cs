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
    [SerializeField] List<GameObject> ItemUI; //�� ���ڿ� ���� �����ǰ� �ִ�?

    [SerializeField] List<ItemInfo> ListInInventory;




    [SerializeField] GameObject ItemUIPrefeb;

    public void GetItem(GameObject item)
    {
        if (item.GetComponent<ItemInfo>() != null)
        {
            int targetInventoryNum = CheckItemInInventory(item.GetComponent<ItemInfo>().GetItemNum());
            PutItemInInventory(targetInventoryNum, item); // �ش� ĭ�� �ش� ������ ����
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
                        ListInInventory[i].GetItemNum() + "�� item" + System.Environment.NewLine + System.Environment.NewLine + "   x" + ListInInventory[i].GetItemCount();
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
                target = i; //���� ���� �� target��° ĭ�̴�.
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
        //�������� ���濡 ������ �� ������ ã��
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
            ListInInventory[target].AddItemCount(item.GetComponent<ItemInfo>().GetItemCount()); //���� ���� �������� ������ŭ ���� �ִ� �ſ��� ���̱⸸ �Ѵ�.
            Destroy(item);
        }
        else if (target >= 0 && ListInInventory[target] == null)
        {
            item.transform.parent = gameObject.transform;
            item.SetActive(false);
            ListInInventory[target] = item.GetComponent<ItemInfo>(); //�ֿ� �������� ������ �� ĭ���� ����.
        }
        else
            Debug.Log("���濡 ��ĭ�� �����"); //������ �� ���� �� �ݴ´�.
    }
}
