using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int Score { get; private set; }
    public TMP_Text scoreText;

    public int score = 0; //현재 점수
    public int targetScore = 1000; // 목표 점수
    public float gameTime = 30f; // 게임 시간 (초)
    private float currentTime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentTime = gameTime;
    }
    void Update()
    {
        currentTime -= Time.deltaTime;

        // 게임 시간이 다 되었을 때
        if (currentTime <= 0)
        {
            HandleFailure();
        }

        // 목표 점수에 도달했을 때
        if (score >= targetScore)
        {
            HandleSuccess();
        }
    }

    public void AddScore(int points)
    {
        Score += points;
        scoreText.text = "Score: " + Score.ToString();
    }

    void HandleSuccess()
    {
        Debug.Log("Game Cleared!");
        SceneManager.LoadScene("mushroomHouse3"); // 다음 씬으로 전환
    }

    void HandleFailure()
    {
        Debug.Log("Game Failed!");
        SceneManager.LoadScene("miniTitle2"); // 시작 화면으로 돌아가기
    }
}
