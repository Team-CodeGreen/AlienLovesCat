using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public int hp;
    public List<string> inventoryItems;

    public PlayerData(int hp, List<string> inventory)
    {
        this.hp = hp;
        this.inventoryItems = inventory;
    }
}