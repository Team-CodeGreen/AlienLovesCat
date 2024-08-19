using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UFOManager : MonoBehaviour
{
    public GameObject UFOButton;
    public GameObject KeyImageSpace;
    public string nextScene;

    private bool playerInRange = false; // �÷��̾ �ݶ��̴� �ȿ� �ִ��� �����ϴ� ����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ʈ���ſ� ���� ������Ʈ�� Player���� Ȯ��
        {
            UFOButton.SetActive(true); // UFO ��ư�� Ȱ��ȭ
            KeyImageSpace.SetActive(true); // KeyImageSpace�� Ȱ��ȭ
            playerInRange = true; // �÷��̾ ���� �ȿ� �ִٰ� ǥ��
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ʈ���ſ��� ��� ������Ʈ�� Player���� Ȯ��
        {
            UFOButton.SetActive(false); // UFO ��ư�� ��Ȱ��ȭ
            KeyImageSpace.SetActive(false); // KeyImageSpace�� ��Ȱ��ȭ
            playerInRange = false; // �÷��̾ ���� ������ �����ٰ� ǥ��
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space)) // �÷��̾ ���� �ȿ� �ְ� �����̽��ٸ� ������
        {
            SceneManager.LoadScene(nextScene); // �� ����
        }
    }
}
