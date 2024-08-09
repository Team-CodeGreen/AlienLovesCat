using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trashBin : MonoBehaviour
{
    public string trashType; // 쓰레기 타입
    public trashSpawner trashSpawner; // TrashSpawner 참조
    public GameObject failImage; // 실패 이미지를 참조 (각 쓰레기통의 Canvas 하위 Image 오브젝트)
    public GameObject goodImage; // Good 이미지를 참조 (각 쓰레기통의 Canvas 하위 Image 오브젝트)

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        Trash trash = other.gameObject.GetComponent<Trash>(); // 충돌한 쓰레기의 Trash 스크립트 가져오기

        if (trash != null)
        {
            if (trash.trashType == trashType)
            {
                Debug.Log("Correct bin!");
                ScoreManager.Instance.AddScore(trash.scoreValue); // 쓰레기의 점수 값을 추가
                ShowGoodImage(); // Good 이미지 표시
            }
            else
            {
                Debug.Log("Wrong bin!");
                ShowFailImage(); // 실패 이미지 표시
            }

            Destroy(other.gameObject); // 현재 쓰레기 제거
            trashSpawner.SpawnTrash(); // 다음 쓰레기 생성
        }
    }

    void ShowFailImage()
    {
        if (failImage != null)
        {
            failImage.SetActive(true); // 실패 이미지 활성화
            Invoke("HideFailImage", 2f); // 2초 후에 이미지를 숨김
        }
    }

    void HideFailImage()
    {
        if (failImage != null)
        {
            failImage.SetActive(false); // 실패 이미지 비활성화
        }
    }

    void ShowGoodImage()
    {
        if (goodImage != null)
        {
            goodImage.SetActive(true); // Good 이미지 활성화
            Invoke("HideGoodImage", 2f); // 2초 후에 이미지를 숨김
        }
    }

    void HideGoodImage()
    {
        if (goodImage != null)
        {
            goodImage.SetActive(false); // Good 이미지 비활성화
        }
    }
}