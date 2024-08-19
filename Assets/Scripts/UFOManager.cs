using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UFOManager : MonoBehaviour
{
    public GameObject UFOButton;
    public GameObject KeyImageSpace;
    public string nextScene;

    private bool playerInRange = false; // 플레이어가 콜라이더 안에 있는지 추적하는 변수

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 트리거에 닿은 오브젝트가 Player인지 확인
        {
            UFOButton.SetActive(true); // UFO 버튼을 활성화
            KeyImageSpace.SetActive(true); // KeyImageSpace를 활성화
            playerInRange = true; // 플레이어가 범위 안에 있다고 표시
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 트리거에서 벗어난 오브젝트가 Player인지 확인
        {
            UFOButton.SetActive(false); // UFO 버튼을 비활성화
            KeyImageSpace.SetActive(false); // KeyImageSpace를 비활성화
            playerInRange = false; // 플레이어가 범위 밖으로 나갔다고 표시
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space)) // 플레이어가 범위 안에 있고 스페이스바를 누르면
        {
            SceneManager.LoadScene(nextScene); // 씬 변경
        }
    }
}
