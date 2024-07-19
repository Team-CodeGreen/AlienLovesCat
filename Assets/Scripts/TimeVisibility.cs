using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeVisibility : MonoBehaviour
{
    public GameObject targetImage; // 비활성화된 이미지 오브젝트
    public float initialDelay = 3.0f; // 처음 비활성화된 상태에서 대기할 시간
    public float visibleDuration = 10.0f; // 활성화된 후 유지될 시간

    void Start()
    {
        if (targetImage != null)
        {
            targetImage.SetActive(false); // 처음에 비활성화 상태로 설정
            StartCoroutine(HandleVisibility());
        }
    }

    IEnumerator HandleVisibility()
    {
        // 초기 대기 시간
        yield return new WaitForSeconds(initialDelay);

        // 이미지 오브젝트 활성화
        targetImage.SetActive(true);
        Debug.Log("Image activated");

        // 활성화된 상태로 유지할 시간
        yield return new WaitForSeconds(visibleDuration);

        // 이미지 오브젝트 비활성화
        targetImage.SetActive(false);
        Debug.Log("Image deactivated");
    }
}
