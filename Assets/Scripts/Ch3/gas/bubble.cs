using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{
    public float speed = 5.0f; // 비눗방울 이동 속도
    public int damage = 1; // 비눗방울의 데미지
    public float maxDistance = 10.0f; // 비눗방울이 이동할 최대 거리

    private Vector2 direction; // 비눗방울 이동 방향
    private Vector3 startPosition; // 비눗방울의 초기 위치

    public void Initialize(Vector2 dir)
    {
        direction = dir.normalized; // 방향 벡터를 정규화
        startPosition = transform.position; // 비눗방울의 초기 위치 저장
    }

    void Update()
    {
        // 비눗방울을 방향으로 계속 이동
        transform.Translate(direction * speed * Time.deltaTime);

        // 비눗방울이 이동한 거리를 계산
        float distanceTraveled = Vector3.Distance(startPosition, transform.position);

        // 이동한 거리가 최대 거리를 넘으면 비눗방울 삭제
        if (distanceTraveled >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ToxicGas"))
        {
            // 유해가스와 충돌했을 때 처리
            ToxicGasEnemy toxicGas = other.GetComponent<ToxicGasEnemy>();
            if (toxicGas != null)
            {
                toxicGas.TakeDamage(damage); // 유해가스에 데미지 적용
                Destroy(gameObject); // 비눗방울 삭제
            }
        }
    }
}
