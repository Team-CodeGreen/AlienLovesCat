using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UFOManager : MonoBehaviour
{
    public GameObject UFOButton;
    public GameObject KeyImageSpace;
    public bool available = false;
    public string ufoScene = "UFO";


    private void Start()
    {
        UFOButton.SetActive(false); // ��ư�� �ʱ� ���¿��� ��Ȱ��ȭ

        /*// ��ư�� OnClick �̺�Ʈ�� �޼��带 ����
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
        }*/
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && available)
        {
            SceneManager.LoadScene(ufoScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ʈ���ſ� ���� ������Ʈ�� Player���� Ȯ��
        {
            UFOButton.SetActive(true); // UFO ��ư�� Ȱ��ȭ
            KeyImageSpace.SetActive(true); // KeyImageSpace�� Ȱ��ȭ
            available = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ʈ���ſ��� ��� ������Ʈ�� Player���� Ȯ��
        {
            UFOButton.SetActive(false); // UFO ��ư�� ��Ȱ��ȭ
            KeyImageSpace.SetActive(false); // KeyImageSpace�� ��Ȱ��ȭ
            available = false;
        }
    }



    // ��ư�� ������ �� ȣ��� �޼���
    public void OnUFOButtonClicked()
    {
        Debug.Log("click");
        SceneManager.LoadScene(ufoScene); // �� ����

    }

}
