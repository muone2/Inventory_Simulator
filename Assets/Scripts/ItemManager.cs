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
        RemoveNotItemInList(); // ������ ���� ��ũ��Ʈ�� ���� �͵��� ������ �������� ����
    }

    private void Update()
    {
        SpawnItem();
    }

    private void RemoveNotItemInList()
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].GetComponent<ItemInfo>() == null) //���� �� ��ũ��Ʈ�� ������ ���� ������ ���� (�װ� �������� �ƴ�)
            {
                item.RemoveAt(i);
                i--;
            }
        } //�� ��� item��ũ��Ʈ�� ������ ����.
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
