using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    //public GameManager manager; //0623 dialog
    public GameObject scanObject; //0623 dialog
    Vector3 dirVec;
    float v;

    public string upAnime = "PlayerUp";
    public string downAnime = "PlayerDown";
    public string rightAnime = "PlayerRight";
    public string leftAnime = "PlayerLeft";
    string nowAnimation = "";
    string oldAnimation = "";

    float axisH;
    float axisV;
    public float angleZ = -90.0f;

    Animator animator;
    Rigidbody2D rbody;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        axisH = Input.GetAxisRaw("Horizontal");
        axisV = Input.GetAxisRaw("Vertical");

        //0623(골드메탈)
        /*
        bool hDown = Input.GetButtonDown("Horiznotal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horiznotal");
        bool vUp = Input.GetButtonUp("Vertical"); */


        Vector2 fromPt = transform.position;
        Vector2 toPt = new Vector2(fromPt.x + axisH, fromPt.y + axisV);
        angleZ = GetAngle(fromPt, toPt);

        if (angleZ >= -45 && angleZ < 45)
        {
            nowAnimation = rightAnime;
        }
        else if (angleZ >= 45 && angleZ <= 135)
        {
            nowAnimation = upAnime;
        }
        else if (angleZ >= -135 && angleZ <= -45)
        {
            nowAnimation = downAnime;
        }
        else
        {
            nowAnimation = leftAnime;
        }

        if (axisH == 0 && axisV == 0)
        {
            animator.Play(null);
        }

        if (nowAnimation != oldAnimation)
        {
            oldAnimation = nowAnimation;
            animator.Play(nowAnimation);
        }
        /*
        //0623
        if (vDown && v == 1) {
            dirVec = Vector3.up;
        }
        else if (vDown && v == -1)
        {
            dirVec = Vector3.down;
        }
        else if (hDown && v == -1)
        {
            dirVec = Vector3.left;
        }
        else if (hDown && v == 1)
        {
            dirVec = Vector3.right;
        }
        
        if (Input.GetButtonDown("Jump") && scanObject != null) {
            manager.Action(scanObject);
        }*/
    }

    void FixedUpdate()
    {
        rbody.velocity = new Vector2(axisH, axisV) * speed;

        //Ray 0623 :캐릭터가 보는 방향으로 ray가 그려진다.
        //Debug.DrawRay(rbody.position, dirVec * 0.7f,new Color(0,1,0));

    }

    float GetAngle(Vector2 p1, Vector2 p2)
    {
        float angle;
        if (axisH != 0 || axisV != 0)
        {
            float dx = p2.x - p1.x;
            float dy = p2.y - p1.y;

            float rad = Mathf.Atan2(dy, dx);

            angle = rad * Mathf.Rad2Deg;
        }
        else
        {
            angle = angleZ;
        }

        return angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Item")
        {
            Debug.Log("아이템을 먹어야하는데 말이죠");
            Destroy(collision.gameObject);
        }

    }
}



