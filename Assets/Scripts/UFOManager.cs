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
        UFOButton.SetActive(false); // 버튼을 초기 상태에서 비활성화

        // 버튼의 OnClick 이벤트에 메서드를 연결
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
        if (other.CompareTag("Player")) // 트리거에 닿은 오브젝트가 Player인지 확인
        {
            UFOButton.SetActive(true); // UFO 버튼을 활성화
            KeyImageSpace.SetActive(true); // KeyImageSpace를 활성화
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 트리거에서 벗어난 오브젝트가 Player인지 확인
        {
            UFOButton.SetActive(false); // UFO 버튼을 비활성화
            KeyImageSpace.SetActive(false); // KeyImageSpace를 비활성화
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 플레이어가 범위 안에 있고 스페이스바를 누르면
        {
            SceneManager.LoadScene(nextScene); // 씬 변경
        }
    }

    // 버튼이 눌렸을 때 호출될 메서드
    private void OnUFOButtonClicked()
    {
            SceneManager.LoadScene(nextScene); // 씬 변경
    }
}
