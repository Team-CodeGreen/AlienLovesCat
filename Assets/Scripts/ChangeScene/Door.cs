using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public Sprite open;
    public Sprite close;
    public bool available = false;

    public GameObject changeScene;

    [SerializeField]
    private GameObject KeyImage;

    // Start is called before the first frame update
    void Start()
    {
        changeScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space) && available)
        {
            isOpen = true;
            UpdateDoor();
            changeScene.SetActive(true);
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            KeyImage.SetActive(true);
            available = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            KeyImage.SetActive(false) ;
            available = false;
        }
    }

    private void UpdateDoor()
    {
        if(isOpen)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = open;
        }else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = close;
        }
    }
}
