using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonManager : MonoBehaviour
{
    // Start ��ư Ŭ�� �� ȣ��� �Լ�
    public void OnStartButtonClicked()
    {
        // "GameScene"�̶�� �̸��� ������ ����
        SceneManager.LoadScene("TitleScene2");
    }
}
