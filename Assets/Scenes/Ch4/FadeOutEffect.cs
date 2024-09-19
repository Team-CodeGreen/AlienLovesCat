using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutEffect : MonoBehaviour
{
    public float delayTime = 5.0f;    // ���̵�ƿ� �� ����� �ð�
    public float fadeDuration = 2.0f; // ���̵�ƿ� �Ǵ� �ð�
    public Image fadeImage;           // ���̵� ȿ���� �� �̹��� (������ �̹���)

    private void Start()
    {
        // �ڷ�ƾ�� �����Ͽ� ������ �ð��� ������ ���̵�ƿ��� ����
        StartCoroutine(FadeOutAfterDelay());
    }

    IEnumerator FadeOutAfterDelay()
    {
        // ������ �ð���ŭ ���
        yield return new WaitForSeconds(delayTime);

        // ���̵�ƿ��� ����
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color fadeColor = fadeImage.color;
        fadeColor.a = 0f; // ���� ������ 0 (������ ����)

        // ���̵�ƿ� ����
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeColor.a = Mathf.Clamp01(elapsedTime / fadeDuration); // ���� ����������
            fadeImage.color = fadeColor; // �̹����� ���� ������Ʈ
            yield return null;
        }

        // ���̵�ƿ��� ������ ������ ������
        fadeColor.a = 1f;
        fadeImage.color = fadeColor;
    }
}