#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitTheGame()
    {
#if UNITY_EDITOR
        // �����Ϳ��� ���� ���� ��
        EditorApplication.isPlaying = false;
#else
        // ����� ���ø����̼ǿ���
        Application.Quit();
#endif
    }
}