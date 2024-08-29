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

    public GameObject clearImage; // Clear 이미지 오브젝트 참조
    public GameObject gameOverImage; // 게임 오버 이미지 오브젝트 참조

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

        // 목표 점수에 도달했을 때
        
        if (Score >= targetScore)
        {
            HandleSuccess();
            
        }
        // 게임 시간이 다 되었을 때
        else if (currentTime <= 0)
        {
            HandleFailure();
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
        clearImage.SetActive(true);

        // 게임을 중단시키고 다음 씬으로 넘어가기
        //        Time.timeScale = 0f; // 게임을 멈추기 위해 시간을 멈춤
        //SceneManager.LoadScene("mushroomHouse4"); // 다음 씬으로 전환
        StartCoroutine(ChangeScene("mushroomHouse4", 2f));
    }


    


    void HandleFailure()
    {
        Debug.Log("Game Failed!");


        gameOverImage.SetActive(true);

        StartCoroutine(ChangeScene("miniTitle2", 2f));
        //SceneManager.LoadScene("miniTitle2"); // 시작 화면으로 돌아가기
    }

    private IEnumerator ChangeScene(string scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
