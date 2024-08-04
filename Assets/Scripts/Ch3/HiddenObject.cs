using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenObject : MonoBehaviour
{
    private void Start()
    {
        // ��ü�� ��ư ������Ʈ�� �߰��ϰ� Ŭ�� �̺�Ʈ�� ����
        Button button = gameObject.AddComponent<Button>();
        button.onClick.AddListener(OnObjectClicked);
    }

    void OnObjectClicked()
    {
        // ��ü�� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
