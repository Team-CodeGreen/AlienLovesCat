using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs; // 쓰레기 프리팹 배열
    public Transform spawnPoint; // 쓰레기가 생성될 위치
    private GameObject currentTrash; // 현재 생성된 쓰레기

    public void Start()
    {
        SpawnTrash(); // 게임 시작 시 첫 쓰레기 생성
    }

    public void SpawnTrash()
    {
        // 이전 쓰레기가 남아있으면 삭제
        if (currentTrash != null)
        {
            Debug.Log("Destroying previous trash: " + currentTrash.name);
            Destroy(currentTrash); // 이전 쓰레기 제거
        }

        // 새로운 쓰레기 생성
        int index = Random.Range(0, trashPrefabs.Length);
        currentTrash = Instantiate(trashPrefabs[index], spawnPoint.position, Quaternion.identity);
        Debug.Log("Spawned new trash: " + currentTrash.name);
    }
}

