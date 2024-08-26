using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpSceneManager : MonoBehaviour
{
    public void GoBackToTitle()
    {
        SceneManager.LoadScene("miniTitle");
    }
}