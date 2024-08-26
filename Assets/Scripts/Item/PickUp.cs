using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    public Item item;

    private GameObject inventory;

    [SerializeField]
    private GameObject KeyImage;

    private GameObject BaseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory");
        BaseCanvas = GameObject.Find("BaseCanvas");

        Transform keyImageTransform = BaseCanvas.transform.Find("KeyImageZ");

        Debug.Log(keyImageTransform);

        if (keyImageTransform != null)
        {
            Debug.Log("키이미지있음");
            GameObject imgZ = keyImageTransform.gameObject;
            KeyImage = imgZ;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && item.available == true)
        {
            inventory.GetComponent<Inventory>().AddItem(item);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            KeyImage.SetActive(true);
            item.available = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            KeyImage.SetActive(false);
            item.available = false;
        }
    }


}
