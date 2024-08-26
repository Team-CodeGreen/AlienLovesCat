using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void StartGame()
    {
        // ù ��° �������� �� �ε�
        SceneManager.LoadScene("Stage1");
    }

    public void OpenHelp()
    {
        // ���� �� �ε�
        SceneManager.LoadScene("HelpScene");
    }
}
