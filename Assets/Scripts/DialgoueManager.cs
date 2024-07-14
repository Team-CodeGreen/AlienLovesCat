using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;  // TMP를 사용하기 위해 추가

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public TMP_Text dialogueText;

    void Start()
    {
        dialogueUI.SetActive(false); // 시작 시 다이얼로그 UI 비활성화
    }

    public void StartDialogue(string dialogue)
    {
        dialogueUI.SetActive(true); // 다이얼로그 UI 활성화
        dialogueText.text = dialogue; // 대화 내용 설정
    }
}