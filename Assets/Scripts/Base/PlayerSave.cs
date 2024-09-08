using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    public static PlayerSave playerSave;

    public int hp = 5;
    public List<Item> items;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(playerSave == null)
        {
            playerSave = this;
            
        }else if(playerSave != this) 
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        Debug.Log("Dont destroy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
