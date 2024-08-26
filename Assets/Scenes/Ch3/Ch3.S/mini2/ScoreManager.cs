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

    public GameObject clearImage; // Clear �̹��� ������Ʈ ����
    public GameObject gameOverImage; // ���� ���� �̹��� ������Ʈ ����

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

        // ��ǥ ������ �������� ��
        
        if (Score >= targetScore)
        {
            HandleSuccess();
            
        }
        // ���� �ð��� �� �Ǿ��� ��
        else if (currentTime <= 0)
        {
            HandleFailure();
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
        clearImage.SetActive(true);

        // ������ �ߴܽ�Ű�� ���� ������ �Ѿ��
        //        Time.timeScale = 0f; // ������ ���߱� ���� �ð��� ����
        //SceneManager.LoadScene("mushroomHouse4"); // ���� ������ ��ȯ
        StartCoroutine(ChangeScene("mushroomHouse4", 2f));
    }


    


    void HandleFailure()
    {
        Debug.Log("Game Failed!");


        gameOverImage.SetActive(true);

        StartCoroutine(ChangeScene("miniTitle2", 2f));
        //SceneManager.LoadScene("miniTitle2"); // ���� ȭ������ ���ư���
    }

    private IEnumerator ChangeScene(string scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
