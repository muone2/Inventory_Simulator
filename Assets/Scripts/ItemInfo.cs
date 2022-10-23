using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] int itemNum;
    [SerializeField] float atteck;
    [SerializeField] float defense;
    [SerializeField] float weight;
    [SerializeField] int Count = 1;

    public int GetItemNum()
    {
        return itemNum;
    }

    public int GetItemCount()
    {
        return Count;
    }

    public void AddItemCount(int count)
    {
        Count += count;
        if (Count <= 0)
            Count = 0;
    }
}
