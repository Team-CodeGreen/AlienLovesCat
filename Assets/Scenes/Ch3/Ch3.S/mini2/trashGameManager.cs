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

        //clearImage.SetActive(ScoreManager.Instance.Score >= targetScore);
    }
    public void RestartGame()
    {
        // ���� ���� �ٽ� �ε��Ͽ� ������ ������ �ʱ�ȭ
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}