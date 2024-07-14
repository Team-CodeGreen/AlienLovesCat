using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;  // TMP�� ����ϱ� ���� �߰�

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public TMP_Text dialogueText;

    void Start()
    {
        dialogueUI.SetActive(false); // ���� �� ���̾�α� UI ��Ȱ��ȭ
    }

    public void StartDialogue(string dialogue)
    {
        dialogueUI.SetActive(true); // ���̾�α� UI Ȱ��ȭ
        dialogueText.text = dialogue; // ��ȭ ���� ����
    }
}