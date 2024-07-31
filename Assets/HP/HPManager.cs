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

    // Start is called before the first frame update
    private void Start()
    {
        image = GetComponent<Image>();
        UpdateHPImages(maxHP);
    }



    public void DecreaseHP(int amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            currentHP = 0;
            Debug.Log("GameOver");
        }

        UpdateHPImages(currentHP);
    }

    public void UpdateHPImages(int hp)
    {
        image.sprite = hpImages[hp];
        
    }
}
