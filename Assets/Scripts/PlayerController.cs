using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
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

    //hp
    public int maxHP = 5;
    public int currentHP;
    public GameObject hpObject;
    

    private bool canMove = true; // 플레이어 움직임 제어 변수 추가

    //데미지 hp 움직이기
    public Transform hpBarTransform;
    public float shakeDuration = 1.0f;
    public float shakeMagnitude = 3.0f;

    private Vector3 originalPos;

    //데미지 플레이어 움직임
    public float knockbackForce = 10.0f;
    public float knockbackDuration = 1.0f;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        currentHP = maxHP;
        hpObject.GetComponent<HPManager>().UpdateHPImages(currentHP);

        if(hpBarTransform != null)
        {
            originalPos = hpBarTransform.localPosition;
        }

    }

    void Update()
    {
        axisH = Input.GetAxisRaw("Horizontal");
        axisV = Input.GetAxisRaw("Vertical");

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

        if (canMove)
        {
            rbody.velocity = new Vector2(axisH, axisV) * speed;
        }
        else
        {
            rbody.velocity = Vector2.zero;
        }
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

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered trigger with: " + other.gameObject.name);
    }

    public void SetMovementEnabled(bool enabled)
    {
        canMove = enabled;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        hpObject.GetComponent<HPManager>().UpdateHPImages(currentHP);

        //Vector3 vector = Quaternion.AngleAxis(0.3f, Vector3.forward) * Vector3.right; rigidbody2d.AddForce(vector * speed);
    
        if(hpBarTransform != null)
        {
            StartCoroutine(ShakeHPBar());
        }

        StartCoroutine(KnockbackPlayer());

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private IEnumerator ShakeHPBar()
    {
        
        float elapsed = 0.0f;

        while(elapsed < shakeDuration)
        {
            float x = UnityEngine.Random.Range(-1f, 1f) * shakeMagnitude;
            float y = UnityEngine.Random.Range(-1f, 1f) * shakeMagnitude;

            hpBarTransform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        hpBarTransform.localPosition = originalPos;
    }

    //knockbackPlayer 함수 들어가긴 하는데 티가 안나
    private IEnumerator KnockbackPlayer()
    {
        Debug.Log("asdf");
        Vector2 knockbackDirection = -transform.right * knockbackForce;
        rbody.AddForce(knockbackDirection, ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);

        rbody.velocity = Vector2.zero;
    }

    void Die()
    {
        Debug.Log("Gameover");
    }
}

