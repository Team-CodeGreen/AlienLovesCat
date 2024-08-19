using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UFOManager : MonoBehaviour
{
    public GameObject UFOButton;
    public GameObject KeyImageSpace;
    public string nextScene;


    private void Start()
    {
        UFOButton.SetActive(false); // ��ư�� �ʱ� ���¿��� ��Ȱ��ȭ

        // ��ư�� OnClick �̺�Ʈ�� �޼��带 ����
        if (UFOButton != null)
        {
            Button buttonComponent = UFOButton.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(OnUFOButtonClicked);
            }
            else
            {
                Debug.LogError("Button component missing on UFOButton.");
            }
        }
        else
        {
            Debug.LogError("UFOButton reference not set.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ʈ���ſ� ���� ������Ʈ�� Player���� Ȯ��
        {
            UFOButton.SetActive(true); // UFO ��ư�� Ȱ��ȭ
            KeyImageSpace.SetActive(true); // KeyImageSpace�� Ȱ��ȭ
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ʈ���ſ��� ��� ������Ʈ�� Player���� Ȯ��
        {
            UFOButton.SetActive(false); // UFO ��ư�� ��Ȱ��ȭ
            KeyImageSpace.SetActive(false); // KeyImageSpace�� ��Ȱ��ȭ
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // �÷��̾ ���� �ȿ� �ְ� �����̽��ٸ� ������
        {
            SceneManager.LoadScene(nextScene); // �� ����
        }
    }

    // ��ư�� ������ �� ȣ��� �޼���
    private void OnUFOButtonClicked()
    {
            SceneManager.LoadScene(nextScene); // �� ����
    }
}
