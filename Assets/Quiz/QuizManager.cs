using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public ToggleGroup toggleGroup;
    public Toggle[] toggles;
    public Button submitButton;
    public TextMeshProUGUI resultText;

    private int correctAnswerIndex = 1;

    void Start()
    {
        submitButton.onClick.AddListener(CheckAnswer);
        resultText.text = "";
    }

    void CheckAnswer()
    {
        Toggle selectedToggle = GetSelectedToggle();

        if (selectedToggle == null)
        {
            resultText.text = "Please select an answer!";
            return;
        }

        int selectedIndex = System.Array.IndexOf(toggles, selectedToggle);

        if(selectedIndex == correctAnswerIndex)
        {
            resultText.text = "Correct!";
        }
        else
        {
            resultText.text = "Incorrect, try again.";
        }
    }

    Toggle GetSelectedToggle()
    {
        foreach(var toggle in toggles)
        {
            if(toggle.isOn)
            {
                return toggle;
            }
        }
        return null;

    }
}
