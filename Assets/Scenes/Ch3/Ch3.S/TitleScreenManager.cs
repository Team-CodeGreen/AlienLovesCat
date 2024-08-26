using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void StartGame()
    {
        // 첫 번째 스테이지 씬 로드
        SceneManager.LoadScene("Stage1");
    }

    public void OpenHelp()
    {
        // 도움말 씬 로드
        SceneManager.LoadScene("HelpScene");
    }
}
