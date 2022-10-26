using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<ItemInfo> ListInInventory = new List<ItemInfo>(); //40ĭ �̸� ���� ��������. �ϴ� ���� null�̰�����.
    [SerializeField] List<int> Count = new List<int>();

    public void GetItem(GameObject item)
    {
        if (item.GetComponent<ItemInfo>() != null)
        {
            int target = CheckItemInInventory(item.GetComponent<ItemInfo>().GetItemNum());
            PutItemInInventory(target, item);
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
        //�������� ���濡 ������
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
            Destroy(item); //Ǯ�� ���� �� ������ �ϴ� ��������. �������.
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
