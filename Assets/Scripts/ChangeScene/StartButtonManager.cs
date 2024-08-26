using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    public string SceneName = "ScenaName";

    // Start 버튼 클릭 시 호출될 함수
    public void OnStartButtonClicked()
    {
        // "GameScene"이라는 이름의 씬으로 변경
        SceneManager.LoadScene(SceneName);
    }
}