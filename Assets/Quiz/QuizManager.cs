using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public Toggle[] toggles;
    public Button submitButton;
    public TextMeshProUGUI resultText;

    public int quizNumber;
    public int correctAnswerIndex;
    public int hintNumber;

    void Start()
    {
        foreach (Toggle toggle in toggles)
        {
            toggle.isOn = false;
            toggle.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggle); });
        }

        submitButton.onClick.AddListener(CheckAnswer);
        switch(quizNumber)
        {
            case 1:
                resultText.text = "ù ��° ��ȣ";
                break;
            case 2:
                resultText.text = "�� ��° ��ȣ";
                break;
            case 3:
                resultText.text = "�� ��° ��ȣ";
                break;
            case 4:
                resultText.text = "�� ��° ��ȣ";
                break;
            default:
                break;
        }
        
    }

    void OnToggleValueChanged(Toggle changedToggle)
    {
        if(changedToggle.isOn)
        {
            foreach(Toggle toggle in toggles)
            {
                if(toggle != changedToggle)
                {
                    toggle.isOn = false;
                }
            }
        }
    }

    void CheckAnswer()
    {
        Toggle selectedToggle = GetSelectedToggle();

        /*if (selectedToggle == null)
        {
            resultText.text = "ù ��° ��ȣ";
            return;
        }*/

        int selectedIndex = System.Array.IndexOf(toggles, selectedToggle);

        if(selectedIndex == correctAnswerIndex)
        {
            resultText.text = "����! Hint: " + hintNumber.ToString();
        }
        else
        {
            resultText.text = "Ʋ�Ƚ��ϴ�. �ٽ� �õ��ϼ���.";
        }
    }

    Toggle GetSelectedToggle()
    {
        foreach(Toggle toggle in toggles)
        {
            if(toggle.isOn)
            {
                return toggle;
            }
        }
        return null;

    }

    
}
