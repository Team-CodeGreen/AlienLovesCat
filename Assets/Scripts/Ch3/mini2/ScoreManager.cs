using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // 싱글톤 인스턴스
    public int Score = 0; // 현재 점수
    public int targetScore = 100; // 목표 점수
    public float gameTime = 30f; // 게임 시간 (초)
    private float currentTime;
    public TMP_Text scoreText; // 점수 표시를 위한 UI 텍스트

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
        if (Score >= targetScore)
        {
            HandleSuccess();
        }
    }

    public void AddScore(int amount)
    {
        Score += amount;
        UpdateScoreText(); // 점수가 변경되었을 때 UI 갱신
        Debug.Log("Current Score: " + Score);
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + Score.ToString();
    }
    void HandleSuccess()
    {
        Debug.Log("Game Cleared!");

        // 게임을 중단시키고 다음 씬으로 넘어가기
        Time.timeScale = 0f; // 게임을 멈추기 위해 시간을 멈춤
        SceneManager.LoadScene("mushroomHouse3"); // 다음 씬으로 전환
    }

    void HandleFailure()
    {
        Debug.Log("Game Failed!");

        // 게임을 중단시키고 시작 씬으로 돌아가기
        Time.timeScale = 0f; // 게임을 멈추기 위해 시간을 멈춤
        SceneManager.LoadScene("miniTitle2"); // 시작 화면으로 돌아가기
    }
}
