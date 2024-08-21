using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleManager : MonoBehaviour
{
    public GameObject bubblePrefab; // �񴰹�� ������
    public float bubbleSpeed = 10.0f; // �񴰹���� �ӵ�

    public string targetSceneName = "BubbleScene"; // �񴰹���� ����� �� �ִ� �� �̸�

    void Update()
    {
        if (IsTargetScene() && Input.GetMouseButtonDown(0)) // ��Ŭ�� �� �񴰹�� �߻�
        {
            FireBubble();
        }
    }

    bool IsTargetScene()
    {
        // ���� ���� ��ǥ ���� ������ Ȯ��
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == targetSceneName;
    }

    void FireBubble()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ���콺 ��ġ
        Vector2 direction = (mousePosition - (Vector2)transform.position).normalized; // ���� ���

        GameObject bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity); // �񴰹�� ����
        bubble bubbleScript = bubble.GetComponent<bubble>();
        bubbleScript.Initialize(direction * bubbleSpeed); // �񴰹�� ���� ����
    }
}
