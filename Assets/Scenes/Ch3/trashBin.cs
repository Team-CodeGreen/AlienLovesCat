using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trashBin : MonoBehaviour
{
    public string trashType; // 쓰레기 타입
    public trashSpawner trashSpawner; // TrashSpawner 참조

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name); // 충돌 확인

        if (other.gameObject.CompareTag(trashType))
        {
            Debug.Log("Correct bin!"); // 올바른 쓰레기통 확인
            ScoreManager.Instance.AddScore(10); // 점수 추가
        }
        else
        {
            Debug.Log("Wrong bin!"); // 잘못된 쓰레기통 확인
        }

        // 현재 쓰레기 제거
        Destroy(other.gameObject);
        // 다음 쓰레기 생성
        trashSpawner.SpawnTrash();
    }
}