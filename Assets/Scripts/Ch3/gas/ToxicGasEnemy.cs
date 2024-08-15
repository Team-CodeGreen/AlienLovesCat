using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGasEnemy : MonoBehaviour
{
    public float moveSpeed = 2.0f; // 유해가스의 이동 속도
    public Vector3 moveDirection = new Vector3(-1, 0, 0); // 유해가스의 이동 방향

    // 타일맵 경계를 정의하는 변수
    public Vector2 minBoundary = new Vector2(-10, -10);
    public Vector2 maxBoundary = new Vector2(10, 10);

    private void Start()
    {
    }

    private void Update()
    {
        // 적을 움직이게 합니다.
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // 적이 타일맵 경계를 벗어나지 않도록 위치를 제한합니다.
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, minBoundary.x, maxBoundary.x),
            Mathf.Clamp(transform.position.y, minBoundary.y, maxBoundary.y),
            transform.position.z
        );

        transform.position = clampedPosition;

        // 경계에 도달했을 때 이동 방향을 반전시킵니다.
        if (transform.position.x <= minBoundary.x || transform.position.x >= maxBoundary.x)
        {
            moveDirection.x = -moveDirection.x;
        }
        if (transform.position.y <= minBoundary.y || transform.position.y >= maxBoundary.y)
        {
            moveDirection.y = -moveDirection.y;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어와 충돌할 때의 처리
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(1); // 플레이어에게 1의 피해를 줍니다.
        }
    }
}