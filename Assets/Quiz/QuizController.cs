using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    [SerializeField]
    private GameObject KeyImage;

    public int QuizNum;

    public GameObject[] QuizScreen;

    private bool canActivate = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canActivate && Input.GetKeyDown(KeyCode.Space))
        {
            QuizScreen[QuizNum].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KeyImage.SetActive(true);
            canActivate = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KeyImage.SetActive(false);
            canActivate = false;
        }
    }
}
