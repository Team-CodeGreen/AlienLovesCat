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
        /*public new string name = "asfd";*/

        if(name != null)
        {
            SceneManager.LoadScene(name);
        }
        // "GameScene"�̶�� �̸��� ������ ����
        SceneManager.LoadScene(SceneName);
    }
}
