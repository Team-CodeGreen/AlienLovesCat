using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public string SceneName = "ScenaName";

    // Start 버튼 클릭 시 호출될 함수
    public void OnStartButtonClicked()
    {
        

        // "GameScene"이라는 이름의 씬으로 변경
        SceneManager.LoadScene(SceneName);
    }

    public void ClickSceneChange(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
