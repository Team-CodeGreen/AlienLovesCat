using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class searchingManager : MonoBehaviour
{
    public GameObject[] hiddenObjects;
    public Timer timer;
    public GameObject clearImage; // Clear 이미지 오브젝트 참조
    public GameObject gameOverImage; // 게임 오버 이미지 오브젝트 참조

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
        timer.StopTimer(); // 타이머 멈추기
        ShowClearImage(); // Clear 이미지 표시
        Invoke("LoadNextStageOrCompletionScene", 2f); // 2초 후 다음 스테이지 또는 완료 씬으로 전환
    }

    void ShowClearImage()
    {
        if (clearImage != null)
        {
            clearImage.SetActive(true); // Clear 이미지 활성화
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
            // 모든 스테이지가 완료된 경우 mushroomHouse 씬으로 전환
            SceneManager.LoadScene("mushroomHouse");
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        if (gameOverImage != null)
        {
            gameOverImage.SetActive(true); // 게임 오버 이미지 활성화
        }
        Invoke("ReturnToTitle", 2f); // 2초 후 타이틀 화면으로 전환
    }

    void ReturnToTitle()
    {
        SceneManager.LoadScene("miniTitle");
    }
}
