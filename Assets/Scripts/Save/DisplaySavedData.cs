using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplaySavedData : MonoBehaviour
{
    public TMP_Text planetNameText;    // 행성 이름 표시용 TMP_Text

    private SaveSystem saveSystem;

    void Start()
    {
        // SaveSystem 싱글턴 인스턴스 가져오기
        saveSystem = SaveSystem.Instance;

        // 저장된 데이터가 있는지 확인
        if (saveSystem.HasSaveFile())
        {
            // 저장된 데이터 로드
            SaveData saveData = saveSystem.LoadGame();

            if (saveData != null)
            {
                planetNameText.text = saveData.planetName;
            }
        }
    }
    void Update() {
        // 저장된 데이터가 있는지 확인
        if (saveSystem.HasSaveFile())
        {
            // 저장된 데이터 로드
            SaveData saveData = saveSystem.LoadGame();

            if (saveData != null)
            {
                planetNameText.text = saveData.planetName;
            }
        }
    }
}
