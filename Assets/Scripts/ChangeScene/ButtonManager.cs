using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public string SceneName = "ScenaName";

    // Start ��ư Ŭ�� �� ȣ��� �Լ�
    public void OnStartButtonClicked()
    {
        // "GameScene"�̶�� �̸��� ������ ����
        SceneManager.LoadScene(SceneName);
    }
}
