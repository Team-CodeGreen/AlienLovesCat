using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScene2 : MonoBehaviour
{
    public void StartGame()
    {
        // 분리수거게임 씬 로드
        SceneManager.LoadScene("trashGame");
    }

    public void OpenHelp()
    {
        // 도움말 씬 로드
        SceneManager.LoadScene("HelpScene2");
    }
}
