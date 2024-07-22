using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    public string SceneName = "ScenaName";

    // Start ��ư Ŭ�� �� ȣ��� �Լ�
    public void OnStartButtonClicked()
    {
        // "GameScene"�̶�� �̸��� ������ ����
        SceneManager.LoadScene(SceneName);
    }
}