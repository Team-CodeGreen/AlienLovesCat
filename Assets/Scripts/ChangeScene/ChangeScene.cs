using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName; // ������ ���� �̸�

    // Ʈ���� �浹�� �߻����� �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("change scene");
        
        if (other.CompareTag("Player")) // Ʈ���ſ� ���� ������Ʈ�� Player���� Ȯ��
        {
            SceneManager.LoadScene(sceneName); // �� ����
        }
    }

    public void UpdateTriggerStatus(bool status)
    {
        GetComponent<BoxCollider2D>().isTrigger = status;
    }
}