using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScene2 : MonoBehaviour
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
