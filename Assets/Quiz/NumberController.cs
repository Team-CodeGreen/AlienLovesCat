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
    public GameObject GetInfoScreen;

    public TextMeshProUGUI resultText;


    void Start()
    {

        UpdateNumberTexts();
        resultText.text = "";
        SupercomputerScreen.SetActive(true);

    }

    public void IncreaseNumber(int index)
    {
       
        currentNumbers[index] = (currentNumbers[index] + 1) % 10;
        UpdateNumberTexts();

    }

    public void DecreaseNumber(int index)
    {
      
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
                resultText.text = "Ʋ�Ƚ��ϴ�. �ݼ��ϼ���.";
                return;
            }
        }

        resultText.text = "����� �����Ǿ����ϴ�.";
        

        SupercomputerScreen.SetActive(false);
        GetInfoScreen.SetActive(true);
    }

    public void ClosePanel()
    {
        SupercomputerScreen.SetActive(false);
    }

}
