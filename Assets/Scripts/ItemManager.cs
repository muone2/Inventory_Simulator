using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] List<GameObject> item = new List<GameObject>();
    [SerializeField] List<GameObject> SpawnPos = new List<GameObject>();

    [SerializeField] float spawnRate = 0f;
    [SerializeField] float spawnCoolTime = 5f;

    private void Start()
    {
        RemoveNotItemInList(); // 아이템 정보 스크립트가 없는 것들을 아이템 정보에서 제거
    }

    private void Update()
    {
        SpawnItem();
    }

    private void RemoveNotItemInList()
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].GetComponent<ItemInfo>() == null) //만약 이 스크립트를 가지고 있지 않으면 제거 (그건 아이템이 아님)
            {
                item.RemoveAt(i);
                i--;
            }
        } //즉 모두 item스크립트를 가지고 있음.
    }

    private void SpawnItem()
    {
        spawnRate += Time.deltaTime;

        if (spawnRate > spawnCoolTime)
        {
            spawnRate = 0f;
            int num = Random.Range(0, item.Count);

            for (int i = 0; i < item.Count; i++)
            {
                if (item[i].GetComponent<ItemInfo>().GetItemNum() == num)
                {
                    Instantiate(item[i], SpawnPos[Random.Range(0, SpawnPos.Count)].transform.position, Quaternion.Euler(Vector3.zero));
                }
            }
        }
    }
}
