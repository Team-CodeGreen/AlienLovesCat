using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName; // 변경할 씬의 이름

    // 트리거 충돌이 발생했을 때 호출되는 함수
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 트리거에 닿은 오브젝트가 Player인지 확인
        {
            SceneManager.LoadScene(sceneName); // 씬 변경
        }
    }
}
