using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicGasEnemy : MonoBehaviour
{
    public enum MoveDirection { Horizontal, Vertical }
    public MoveDirection moveDirection = MoveDirection.Horizontal;
    public float moveDistance = 5.0f;
    public float speed = 2.0f;
    public int damage = 1;
    public int health = 5;

    public GameObject deathEffectPrefab; // ���ذ��� ����� ���� ��ƼŬ ȿ�� ������
    public GameObject dropItemPrefab; // ����� �������� ������
    public float dropChance = 0.5f; // �������� ��ӵ� Ȯ�� (0.5f = 50%)

   

    private Vector3 startPoint;
    private Vector3 target;
    private Animator animator;
    private bool isDead = false; // ���� ���¸� �����ϴ� ����


    void Start()
    {
        startPoint = transform.position;
        animator = GetComponent<Animator>();
        SetTarget();
    }

    void Update()
    {
        if (!isDead) // ���� �ʾ��� ���� �������� ó��
        {
            MoveGuard();
        }
    }

    void SetTarget()
    {
        if (moveDirection == MoveDirection.Horizontal)
        {
            target = new Vector3(startPoint.x + moveDistance, startPoint.y, startPoint.z);
            animator.Play("GasRight");
        }
        else
        {
            target = new Vector3(startPoint.x, startPoint.y - moveDistance, startPoint.z);
            animator.Play("GasDown");
        }
    }

    void MoveGuard()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == startPoint)
        {
            if (moveDirection == MoveDirection.Horizontal)
            {
                target = new Vector3(startPoint.x + moveDistance, startPoint.y, startPoint.z);
                animator.Play("GasRight");
            }
            else
            {
                target = new Vector3(startPoint.x, startPoint.y - moveDistance, startPoint.z);
                animator.Play("GasDown");
            }
        }
        else if (transform.position == target)
        {
            if (moveDirection == MoveDirection.Horizontal)
            {
                target = startPoint;
                animator.Play("GasLeft");
            }
            else
            {
                target = startPoint;
                animator.Play("GasUp");
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true; // ���� ���·� ����

        // ���ذ��� ����� �� ��ƼŬ ȿ�� ����
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        // Ȯ���� ���� ������ ���
        if (dropItemPrefab != null && Random.value <= dropChance)
        {
            Debug.Log("������ ��ӵ�"); // ����� �α� �߰�
            Instantiate(dropItemPrefab, transform.position, Quaternion.identity);
            
        }
        else
        {
            Debug.Log("������ ��� �� ��"); // ����� �α� �߰�
        }

        // ��ü�� ��Ȱ��ȭ���� �ʰ� ��ġ�� ���� �� �ٽ� ��Ÿ������ ��
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        // ��ü�� ȭ�� ������ �̵����� ����
        transform.position = new Vector3(10000, 10000, 0);

        // 5�� ���
        yield return new WaitForSeconds(10f);

        // �ٽ� Ȱ��ȭ�Ͽ� �ʱ� ��ġ�� �ǵ�����, ü�� �ʱ�ȭ
        transform.position = startPoint;
        health = 5; // ���÷� 5�� �ʱ�ȭ, �ʿ信 ���� ���� ����
        isDead = false; // ���� ���� ����
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDead)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damage);
            }
        }
    }
}
