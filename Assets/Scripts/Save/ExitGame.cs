#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitTheGame()
    {
#if UNITY_EDITOR
        // 에디터에서 실행 중일 때
        EditorApplication.isPlaying = false;
#else
        // 빌드된 애플리케이션에서
        Application.Quit();
#endif
    }
}