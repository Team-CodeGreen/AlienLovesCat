using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenObject : MonoBehaviour
{
    private void Start()
    {
        // 객체에 버튼 컴포넌트를 추가하고 클릭 이벤트를 설정
        Button button = gameObject.AddComponent<Button>();
        button.onClick.AddListener(OnObjectClicked);
    }

    void OnObjectClicked()
    {
        // 객체를 비활성화
        gameObject.SetActive(false);
    }
}
