using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class searchingManager : MonoBehaviour
{
    public GameObject[] hiddenObjects;
    public Timer timer;
    public GameObject clearImage; // Clear �̹��� ������Ʈ ����
    public GameObject gameOverImage; // ���� ���� �̹��� ������Ʈ ����

    private int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        bool allObjectsFound = true;
        foreach (GameObject obj in hiddenObjects)
        {
            if (obj.activeSelf)
            {
                allObjectsFound = false;
                break;
            }
        }

        if (allObjectsFound)
        {
            GameCompleted();
        }
    }

    void GameCompleted()
    {
        Debug.Log("You found all hidden objects!");
        timer.StopTimer(); // Ÿ�̸� ���߱�
        ShowClearImage(); // Clear �̹��� ǥ��
        Invoke("LoadNextStageOrCompletionScene", 2f); // 2�� �� ���� �������� �Ǵ� �Ϸ� ������ ��ȯ
    }

    void ShowClearImage()
    {
        if (clearImage != null)
        {
            clearImage.SetActive(true); // Clear �̹��� Ȱ��ȭ
        }
    }

    void LoadNextStageOrCompletionScene()
    {
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("All stages completed!");
            // ��� ���������� �Ϸ�� ��� mushroomHouse ������ ��ȯ
            SceneManager.LoadScene("mushroomHouse");
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        if (gameOverImage != null)
        {
            gameOverImage.SetActive(true); // ���� ���� �̹��� Ȱ��ȭ
        }
        Invoke("ReturnToTitle", 2f); // 2�� �� Ÿ��Ʋ ȭ������ ��ȯ
    }

    void ReturnToTitle()
    {
        SceneManager.LoadScene("miniTitle");
    }
}
