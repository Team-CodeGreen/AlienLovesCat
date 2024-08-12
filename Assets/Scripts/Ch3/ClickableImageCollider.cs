using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableImage : MonoBehaviour
{
    public GameObject checkMarkPrefab; // üũ ��ũ ������ ����

    void Start()
    {
    }

    void OnMouseDown()
    {
        Debug.Log("Image clicked");

        // üũ ��ũ ǥ��
        ShowCheckMark();
    }

    void ShowCheckMark()
    {
        checkMarkPrefab.SetActive(true);
        
    }
}