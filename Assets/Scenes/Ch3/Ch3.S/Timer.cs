using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60f; // 타이머 제한 시간 (초)
    private float currentTime;
    public TextMeshProUGUI timerText;
    private bool isGameOver = false;
    public searchingManager searchingManager; // searchingManager 참조

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
                searchingManager.GameOver(); // searchingManager의 GameOver 메서드 호출
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

    public void StopTimer() // 타이머 멈추는 메서드 추가
    {
        isGameOver = true;
        // 타이머를 멈추고 필요한 추가 작업을 여기에서 수행할 수 있습니다.
    }
}