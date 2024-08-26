using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs; // ������ ������ �迭
    public Transform spawnPoint; // �����Ⱑ ������ ��ġ
    private GameObject currentTrash; // ���� ������ ������

    public void Start()
    {
        SpawnTrash(); // ���� ���� �� ù ������ ����
    }

    public void SpawnTrash()
    {
        // ���� �����Ⱑ ���������� ����
        if (currentTrash != null)
        {
            Debug.Log("Destroying previous trash: " + currentTrash.name);
            Destroy(currentTrash); // ���� ������ ����
        }

        // ���ο� ������ ����
        int index = Random.Range(0, trashPrefabs.Length);
        currentTrash = Instantiate(trashPrefabs[index], spawnPoint.position, Quaternion.identity);
        Debug.Log("Spawned new trash: " + currentTrash.name);
    }
}

