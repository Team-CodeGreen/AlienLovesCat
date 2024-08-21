using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleManager : MonoBehaviour
{
    public GameObject bubblePrefab; // 비눗방울 프리팹
    public float bubbleSpeed = 10.0f; // 비눗방울의 속도

    public string targetSceneName = "BubbleScene"; // 비눗방울을 사용할 수 있는 씬 이름

    void Update()
    {
        if (IsTargetScene() && Input.GetMouseButtonDown(0)) // 좌클릭 시 비눗방울 발사
        {
            FireBubble();
        }
    }

    bool IsTargetScene()
    {
        // 현재 씬이 목표 씬과 같은지 확인
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == targetSceneName;
    }

    void FireBubble()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 위치
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized; // 방향 계산

        GameObject bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity); // 비눗방울 생성
        bubble bubbleScript = bubble.GetComponent<bubble>();
        bubbleScript.Initialize(direction * bubbleSpeed); // 비눗방울 방향 설정
    }
}
