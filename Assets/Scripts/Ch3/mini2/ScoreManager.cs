using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // �̱��� �ν��Ͻ�
    public int Score = 0; // ���� ����
    public int targetScore = 100; // ��ǥ ����
    public float gameTime = 30f; // ���� �ð� (��)
    private float currentTime;
    public TMP_Text scoreText; // ���� ǥ�ø� ���� UI �ؽ�Ʈ

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
        if (Score >= targetScore)
        {
            HandleSuccess();
        }
    }

    public void AddScore(int amount)
    {
        Score += amount;
        UpdateScoreText(); // ������ ����Ǿ��� �� UI ����
        Debug.Log("Current Score: " + Score);
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + Score.ToString();
    }
    void HandleSuccess()
    {
        Debug.Log("Game Cleared!");

        // ������ �ߴܽ�Ű�� ���� ������ �Ѿ��
        Time.timeScale = 0f; // ������ ���߱� ���� �ð��� ����
        SceneManager.LoadScene("mushroomHouse3"); // ���� ������ ��ȯ
    }

    void HandleFailure()
    {
        Debug.Log("Game Failed!");

        // ������ �ߴܽ�Ű�� ���� ������ ���ư���
        Time.timeScale = 0f; // ������ ���߱� ���� �ð��� ����
        SceneManager.LoadScene("miniTitle2"); // ���� ȭ������ ���ư���
    }
}
