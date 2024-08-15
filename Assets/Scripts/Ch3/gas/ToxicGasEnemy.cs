using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGasEnemy : MonoBehaviour
{
    public float moveSpeed = 2.0f; // ���ذ����� �̵� �ӵ�
    public Vector3 moveDirection = new Vector3(-1, 0, 0); // ���ذ����� �̵� ����

    // Ÿ�ϸ� ��踦 �����ϴ� ����
    public Vector2 minBoundary = new Vector2(-10, -10);
    public Vector2 maxBoundary = new Vector2(10, 10);

    private void Start()
    {
    }

    private void Update()
    {
        // ���� �����̰� �մϴ�.
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // ���� Ÿ�ϸ� ��踦 ����� �ʵ��� ��ġ�� �����մϴ�.
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, minBoundary.x, maxBoundary.x),
            Mathf.Clamp(transform.position.y, minBoundary.y, maxBoundary.y),
            transform.position.z
        );

        transform.position = clampedPosition;

        // ��迡 �������� �� �̵� ������ ������ŵ�ϴ�.
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
        // �÷��̾�� �浹�� ���� ó��
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(1); // �÷��̾�� 1�� ���ظ� �ݴϴ�.
        }
    }
}