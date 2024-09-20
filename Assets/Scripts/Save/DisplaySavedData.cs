using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplaySavedData : MonoBehaviour
{
    public TMP_Text planetNameText;    // �༺ �̸� ǥ�ÿ� TMP_Text

    private SaveSystem saveSystem;

    void Start()
    {
        // SaveSystem �̱��� �ν��Ͻ� ��������
        saveSystem = SaveSystem.Instance;

        // ����� �����Ͱ� �ִ��� Ȯ��
        if (saveSystem.HasSaveFile())
        {
            // ����� ������ �ε�
            SaveData saveData = saveSystem.LoadGame();

            if (saveData != null)
            {
                planetNameText.text = saveData.planetName;
            }
        }
    }
    void Update() {
        // ����� �����Ͱ� �ִ��� Ȯ��
        if (saveSystem.HasSaveFile())
        {
            // ����� ������ �ε�
            SaveData saveData = saveSystem.LoadGame();

            if (saveData != null)
            {
                planetNameText.text = saveData.planetName;
            }
        }
    }
}
