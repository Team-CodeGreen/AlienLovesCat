using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//일정 시간이 지나면 씬이 바뀌게 하는 스크립트

public class TimeScene : MonoBehaviour
{
    public float waitSecond=2.0f; //기다릴 시간
    public string sceneToLoad = "NextScene"; // 변경할 씬의 이름

    void Start()
    {
        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(waitSecond); //waitSecond 동안 기다림
        SceneManager.LoadScene(sceneToLoad); //다음 씬을 불러옴
    }
}
