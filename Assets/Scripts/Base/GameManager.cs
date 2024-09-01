using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentHP;
    public int maxHP;
    public List<Item> inventoryItems = new List<Item>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetHP(int hp)
    {
        currentHP = hp;
    }

    public void AddItem(Item item)
    {
        inventoryItems.Add(item);
    }

    public void RemoveItem(Item item)
    {
        inventoryItems.Remove(item);
    }
}
