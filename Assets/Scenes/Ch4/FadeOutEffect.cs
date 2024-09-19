using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutEffect : MonoBehaviour
{
    public float delayTime = 5.0f;    // 페이드아웃 전 대기할 시간
    public float fadeDuration = 2.0f; // 페이드아웃 되는 시간
    public Image fadeImage;           // 페이드 효과를 낼 이미지 (검은색 이미지)

    private void Start()
    {
        // 코루틴을 시작하여 지정된 시간이 지나면 페이드아웃을 시작
        StartCoroutine(FadeOutAfterDelay());
    }

    IEnumerator FadeOutAfterDelay()
    {
        // 설정된 시간만큼 대기
        yield return new WaitForSeconds(delayTime);

        // 페이드아웃을 시작
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color fadeColor = fadeImage.color;
        fadeColor.a = 0f; // 시작 투명도는 0 (완전히 투명)

        // 페이드아웃 실행
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeColor.a = Mathf.Clamp01(elapsedTime / fadeDuration); // 점점 검은색으로
            fadeImage.color = fadeColor; // 이미지의 투명도 업데이트
            yield return null;
        }

        // 페이드아웃이 끝나면 완전히 검은색
        fadeColor.a = 1f;
        fadeImage.color = fadeColor;
    }
}