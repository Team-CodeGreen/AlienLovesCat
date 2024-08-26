using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeVisibility : MonoBehaviour
{
    public GameObject targetImage; // ��Ȱ��ȭ�� �̹��� ������Ʈ
    public float initialDelay = 3.0f; // ó�� ��Ȱ��ȭ�� ���¿��� ����� �ð�
    public float visibleDuration = 10.0f; // Ȱ��ȭ�� �� ������ �ð�

    void Start()
    {
        if (targetImage != null)
        {
            targetImage.SetActive(false); // ó���� ��Ȱ��ȭ ���·� ����
            StartCoroutine(HandleVisibility());
        }
    }

    IEnumerator HandleVisibility()
    {
        // �ʱ� ��� �ð�
        yield return new WaitForSeconds(initialDelay);

        // �̹��� ������Ʈ Ȱ��ȭ
        targetImage.SetActive(true);
        Debug.Log("Image activated");

        // Ȱ��ȭ�� ���·� ������ �ð�
        yield return new WaitForSeconds(visibleDuration);

        // �̹��� ������Ʈ ��Ȱ��ȭ
        targetImage.SetActive(false);
        Debug.Log("Image deactivated");
    }
}
