using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControll : MonoBehaviour
{
    public Animator creditsAnimator;

    void Start()
    {
        creditsAnimator = GetComponent<Animator>();
        StartCoroutine(ScrollCredits());
    }

    IEnumerator ScrollCredits()
    {
        creditsAnimator.SetTrigger("StartScroll"); // 애니메이션 시작 트리거
        yield return new WaitForSeconds(creditsAnimator.GetCurrentAnimatorStateInfo(0).length);
        Debug.Log("Credits finished scrolling.");
    }
}
