using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScene2 : MonoBehaviour
{
    public void StartGame()
    {
        // �и����Ű��� �� �ε�
        SceneManager.LoadScene("trashGame");
    }

    public void OpenHelp()
    {
        // ���� �� �ε�
        SceneManager.LoadScene("HelpScene2");
    }
}
