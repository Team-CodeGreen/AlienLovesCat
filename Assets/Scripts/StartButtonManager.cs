using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    // Start ��ư Ŭ�� �� ȣ��� �Լ�
    public void OnStartButtonClicked()
    {
        // "GameScene"�̶�� �̸��� ������ ����
        SceneManager.LoadScene("Title2");
    }
}