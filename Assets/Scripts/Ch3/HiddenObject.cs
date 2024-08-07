using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiddenObject : MonoBehaviour
{
    public GameObject checkMarkPrefab; // 체크 마크 프리팹 참조

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
        //checkMarkPrefab.SetActive(true);
    }
}
