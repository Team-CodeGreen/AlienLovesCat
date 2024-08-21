using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableImage : MonoBehaviour
{
    public GameObject checkMarkPrefab; // 체크 마크 프리팹 참조

    void Start()
    {
    }

    void OnMouseDown()
    {
        Debug.Log("Image clicked");

        // 체크 마크 표시
        ShowCheckMark();
    }

    void ShowCheckMark()
    {
        checkMarkPrefab.SetActive(true);
        
    }
}