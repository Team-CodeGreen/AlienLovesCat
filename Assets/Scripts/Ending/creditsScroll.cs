using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsScroll : MonoBehaviour
{
    public RectTransform creditsText;  // ũ���� �ؽ�Ʈ�� RectTransform
    public RectTransform[] creditImages; // ũ���� �̹������� RectTransform �迭
    public float scrollSpeed = 50f;     // ��ũ�� �ӵ�
    public float endPositionY = 800f;   // �ؽ�Ʈ�� ���� ��ġ�� Y��

    private Vector2 originalTextPosition; // �ؽ�Ʈ �ʱ� ��ġ ����
    private Vector2[] originalImagePositions; // �̹������� �ʱ� ��ġ ����

    void Start()
    {
        originalTextPosition = creditsText.anchoredPosition; // �ؽ�Ʈ�� �ʱ� ��ġ ����

        // �� �̹����� �ʱ� ��ġ�� ����
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
            // �ؽ�Ʈ�� ���� �̵�
            creditsText.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);

            // �� �̹����� ���� �̵�
            for (int i = 0; i < creditImages.Length; i++)
            {
                creditImages[i].anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
            }

            yield return null;
        }

        // ��ũ���� ������ �߰� ����
        Debug.Log("Credits finished scrolling.");
    }
}
