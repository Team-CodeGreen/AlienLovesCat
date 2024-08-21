using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{
    public float speed = 5.0f; // �񴰹�� �̵� �ӵ�
    public int damage = 1; // �񴰹���� ������
    public float maxDistance = 10.0f; // �񴰹���� �̵��� �ִ� �Ÿ�

    private Vector2 direction; // �񴰹�� �̵� ����
    private Vector3 startPosition; // �񴰹���� �ʱ� ��ġ

    public void Initialize(Vector2 dir)
    {
        direction = dir.normalized; // ���� ���͸� ����ȭ
        startPosition = transform.position; // �񴰹���� �ʱ� ��ġ ����
    }

    void Update()
    {
        // �񴰹���� �������� ��� �̵�
        transform.Translate(direction * speed * Time.deltaTime);

        // �񴰹���� �̵��� �Ÿ��� ���
        float distanceTraveled = Vector3.Distance(startPosition, transform.position);

        // �̵��� �Ÿ��� �ִ� �Ÿ��� ������ �񴰹�� ����
        if (distanceTraveled >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ToxicGas"))
        {
            // ���ذ����� �浹���� �� ó��
            ToxicGasEnemy toxicGas = other.GetComponent<ToxicGasEnemy>();
            if (toxicGas != null)
            {
                toxicGas.TakeDamage(damage); // ���ذ����� ������ ����
                Destroy(gameObject); // �񴰹�� ����
            }
        }
    }
}
