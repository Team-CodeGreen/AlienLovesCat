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

    public int score = 0; //���� ����
    public int targetScore = 1000; // ��ǥ ����
    public float gameTime = 30f; // ���� �ð� (��)
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

        // ���� �ð��� �� �Ǿ��� ��
        if (currentTime <= 0)
        {
            HandleFailure();
        }

        // ��ǥ ������ �������� ��
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
        SceneManager.LoadScene("mushroomHouse3"); // ���� ������ ��ȯ
    }

    void HandleFailure()
    {
        Debug.Log("Game Failed!");
        SceneManager.LoadScene("miniTitle2"); // ���� ȭ������ ���ư���
    }
}
