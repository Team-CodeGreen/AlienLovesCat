using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public void FadeIn()
    {
        Debug.Log("FadeIn시작");
        StartCoroutine(CoFadeIn());
        Debug.Log("FadeIn끝");
    }

    public void FadeOut()
    {
        Debug.Log("FadeOut시작");
        StartCoroutine(CoFadeOut());
        Debug.Log("FadeOut끝");
    }

    IEnumerator CoFadeIn()
    {
        Image fadeScreen = gameObject.GetComponent<Image>();
        Color tempColor = fadeScreen.color;

        while(tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / 1f;
            fadeScreen.color = tempColor;

            if (tempColor.a >= 1f) tempColor.a = 1f;

            yield return null;
        }

        fadeScreen.color = tempColor;
    }

    IEnumerator CoFadeOut()
    {
        Image fadeScreen = gameObject.GetComponent<Image>();
        Color tempColor = fadeScreen.color;

        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / 1f;
            fadeScreen.color = tempColor;

            if (tempColor.a <= 0f) tempColor.a = 0f;

            yield return null;
        }

        fadeScreen.color = tempColor;
    }
}
