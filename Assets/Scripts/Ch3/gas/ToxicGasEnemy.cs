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

    void Start()
    {
        startPoint = transform.position;
        animator = GetComponent<Animator>();
        SetTarget();
    }

    void Update()
    {
        MoveGuard();
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

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // 유해가스 사라질 때 파티클 효과 생성
        Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);

        // 유해가스 오브젝트 삭제
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damage);
            }
        }
    }
}