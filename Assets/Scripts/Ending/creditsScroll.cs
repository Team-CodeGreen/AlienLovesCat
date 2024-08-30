using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsScroll : MonoBehaviour
{
    public RectTransform creditsText;  // 크레딧 텍스트의 RectTransform
    public RectTransform[] creditImages; // 크레딧 이미지들의 RectTransform 배열
    public float scrollSpeed = 50f;     // 스크롤 속도
    public float endPositionY = 800f;   // 텍스트가 끝날 위치의 Y값

    private Vector2 originalTextPosition; // 텍스트 초기 위치 저장
    private Vector2[] originalImagePositions; // 이미지들의 초기 위치 저장

    void Start()
    {
        originalTextPosition = creditsText.anchoredPosition; // 텍스트의 초기 위치 저장

        // 각 이미지의 초기 위치를 저장
        originalImagePositions = new Vector2[creditImages.Length];
        for (int i = 0; i < creditImages.Length; i++)
        {
            originalImagePositions[i] = creditImages[i].anchoredPosition;
        }

        StartCoroutine(ScrollCredits());
    }

    IEnumerator ScrollCredits()
    {
        while (creditsText.anchoredPosition.y < endPositionY)
        {
            // 텍스트를 위로 이동
            creditsText.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);

            // 각 이미지를 위로 이동
            for (int i = 0; i < creditImages.Length; i++)
            {
                creditImages[i].anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
            }

            yield return null;
        }

        // 스크롤이 끝나면 추가 동작
        Debug.Log("Credits finished scrolling.");
    }
}
