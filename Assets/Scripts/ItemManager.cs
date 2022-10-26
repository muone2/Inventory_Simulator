using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] List<GameObject> item = new List<GameObject>();
    [SerializeField] List<GameObject> SpawnPos = new List<GameObject>();
    public Inventory a;

    [SerializeField] float rate = 0f;
    [SerializeField] float spawnCoolTime = 5f;


    private void Start()
    {
        for (int i = 0; i < item.Count; i++) {
            if (item[i].GetComponent<ItemInfo>() == null) //만약 이 스크립트를 가지고 있지 않으면 제거 (그건 아이템이 아님)
            {
                item.RemoveAt(i);
                i--;
            }
        } //즉 모두 item스크립트를 가지고 있음.
    }

    private void Update()
    {
        rate += Time.deltaTime;

        if (rate > spawnCoolTime)
        {
            rate = 0f;
            SpawnItem(Random.Range(0, item.Count));
        }
    }

    public void CallSpawnItem(int num)
    {
        SpawnItem(num);
    }

    private void SpawnItem(int num)
    {   
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].GetComponent<ItemInfo>().GetItemNum() == num)
            {
                Instantiate(item[i], SpawnPos[Random.Range(0, SpawnPos.Count)].transform.position, Quaternion.Euler(Vector3.zero));
            }
        }
    }
}
