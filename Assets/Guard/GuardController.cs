using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GuardController : MonoBehaviour
{
    public enum MoveDirection { Horizontal, Vertical}
    public MoveDirection moveDirection = MoveDirection.Horizontal;
    public float moveDistance = 5.0f;
    public float speed = 2.0f;
    public int damage = 1;

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
        if(moveDirection == MoveDirection.Horizontal)
        {
            target = new Vector3(startPoint.x + moveDistance, startPoint.y, startPoint.z);
            animator.Play("GuardRight");
        }
        else
        {
            target = new Vector3(startPoint.x, startPoint.y - moveDistance, startPoint.z);
            animator.Play("GuardDown");
        }
    }

    void MoveGuard()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == startPoint)
        {
            if(moveDirection == MoveDirection.Horizontal)
            {
                target = new Vector3(startPoint.x + moveDistance, startPoint.y, startPoint.z);
                animator.Play("GuardRight");
            }
            else
            {
                target = new Vector3(startPoint.x, startPoint.y - moveDistance, startPoint.z);
                animator.Play("GuardDown");
            }
        }
        else if (transform.position == target)
        {
            if(moveDirection == MoveDirection.Horizontal)
            {
                target = startPoint;
                animator.Play("GuardLeft");
            }
            else
            {
                target = startPoint;
                animator.Play("GuardUp");
            }
        }
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
