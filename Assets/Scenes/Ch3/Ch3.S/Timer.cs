using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60f; // Ÿ�̸� ���� �ð� (��)
    private float currentTime;
    public TextMeshProUGUI timerText;
    private bool isGameOver = false;
    public searchingManager searchingManager; // searchingManager ����

    void Start()
    {
        currentTime = timeLimit;
    }

    void Update()
    {
        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();

            if (currentTime <= 0)
            {
                UpdateTimerText();
                currentTime = 0;
                isGameOver = true;
                searchingManager.GameOver(); // searchingManager�� GameOver �޼��� ȣ��
            }
        }
    }

    void UpdateTimerText()
    {
        if(currentTime <= 0)
        {
            timerText.text = "0:00";
        } else
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StopTimer() // Ÿ�̸� ���ߴ� �޼��� �߰�
    {
        isGameOver = true;
        // Ÿ�̸Ӹ� ���߰� �ʿ��� �߰� �۾��� ���⿡�� ������ �� �ֽ��ϴ�.
    }
}