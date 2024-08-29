using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenObject : MonoBehaviour
{
    public GameObject check; // üũ ��ũ ������ ����

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
        check.SetActive(true);
        //checkMarkPrefab.SetActive(true);
    }
}
