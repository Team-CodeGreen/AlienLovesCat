using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberController : MonoBehaviour
{
    public TextMeshProUGUI[] numberTexts;
    private int[] currentNumbers = new int[4];

    private int[] correctPassword = { 2, 2, 6, 8 };

    public GameObject SupercomputerScreen;

    void Start()
    {
        Debug.Log(correctPassword[0]);
        Debug.Log(currentNumbers[0]);
        UpdateNumberTexts();
    }

    public void IncreaseNumber(int index)
    {
        Debug.Log("증가");
        currentNumbers[index] = (currentNumbers[index] + 1) % 10;
        UpdateNumberTexts();
    }

    public void DecreaseNumber(int index)
    {
        Debug.Log("감소");
        currentNumbers[index] = (currentNumbers[index] - 1 + 10) % 10;
        UpdateNumberTexts();
    }

    private void UpdateNumberTexts()
    {
        for (int i = 0; i < numberTexts.Length; i++)
        {
            numberTexts[i].text = currentNumbers[i].ToString();
        }
        
    }

    public void CheckPassword()
    {
        for (int i = 0; i < correctPassword.Length; i++)
        {
            if (currentNumbers[i] != correctPassword[i])
            {
                Debug.Log("틀림~");
                SupercomputerScreen.SetActive(false);
                return;
            }
        }
        Debug.Log("맞음!");
        SupercomputerScreen.SetActive(false);
    }

}
