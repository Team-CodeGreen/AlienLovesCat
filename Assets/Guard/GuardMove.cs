using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMove : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform target;

    void Start()
    {
        target = pointA;        
    }

    void Update()
    {
        Move();
        CheckSwitchTarget();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void CheckSwitchTarget()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target = target == pointA ? pointB : pointA;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            HPManager hpManager = collision.gameObject.GetComponent<HPManager>();
            Debug.Log("hp?");
            if (hpManager != null)
            {
                hpManager.DecreaseHP(1);
                Debug.Log("hp");
            }
            
        }
    }
}
