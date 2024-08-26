using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trashGameManager : MonoBehaviour
{
    public float timeLimit = 30f;
    public int targetScore = 100;
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public GameObject clearPanel;

    private float timeRemaining;
    private bool gameActive;

    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        timeRemaining = timeLimit;
        gameActive = true;
        clearPanel.SetActive(false);
    }

    void Update()
    {
        if (gameActive)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "" + Mathf.Ceil(timeRemaining).ToString();

            if (timeRemaining <= 0 || ScoreManager.Instance.Score >= targetScore)
            {
                EndGame();
            }
        }
    }

    void EndGame()
    {
        gameActive = false;
        clearPanel.SetActive(ScoreManager.Instance.Score >= targetScore);
    }
    public void RestartGame()
    {
        // 현재 씬을 다시 로드하여 게임을 완전히 초기화
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
