using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    Image image;
    public int maxHP = 5;
    public int currentHP;
    public Sprite[] hpImages;

    private GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        image = GetComponent<Image>();
        player = GameObject.Find("Player");
        UpdateHPImages(player.GetComponent<PlayerController>().currentHP);
    }

    public void UpdateHPImages(int hp)
    {
        if(image != null)
        {
            image.sprite = hpImages[hp];

        }
    }
}
