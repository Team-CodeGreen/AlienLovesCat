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

    public GameObject deathEffectPrefab; // 유해가스 사라질 때의 파티클 효과 프리팹

    private Vector3 startPoint;
    private Vector3 target;
    private Animator animator;
    private bool isDead = false; // 죽은 상태를 추적하는 변수

    void Start()
    {
        startPoint = transform.position;
        animator = GetComponent<Animator>();
        SetTarget();
    }

    void Update()
    {
        if (!isDead) // 죽지 않았을 때만 움직임을 처리
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
        isDead = true; // 죽은 상태로 설정

        // 유해가스 사라질 때 파티클 효과 생성
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        // 객체를 비활성화하지 않고 위치를 숨긴 후 다시 나타나도록 함
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        // 객체를 화면 밖으로 이동시켜 숨김
        transform.position = new Vector3(10000, 10000, 0);

        // 5초 대기
        yield return new WaitForSeconds(5f);

        // 다시 활성화하여 초기 위치로 되돌리고, 체력 초기화
        transform.position = startPoint;
        health = 5; // 예시로 5로 초기화, 필요에 따라 조정 가능
        isDead = false; // 죽은 상태 해제
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
