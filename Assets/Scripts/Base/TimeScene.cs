using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//���� �ð��� ������ ���� �ٲ�� �ϴ� ��ũ��Ʈ

public class TimeScene : MonoBehaviour
{
    public float waitSecond=2.0f; //��ٸ� �ð�
    public string sceneToLoad = "NextScene"; // ������ ���� �̸�

    void Start()
    {
        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(waitSecond); //waitSecond ���� ��ٸ�
        SceneManager.LoadScene(sceneToLoad); //���� ���� �ҷ���
    }
}
