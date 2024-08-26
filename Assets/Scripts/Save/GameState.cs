using System.Collections.Generic;

[System.Serializable]
public class GameState
{
    public string planetName;  // 행성 이름
    public int hp;             // 플레이어의 HP
    public string sceneName;   // 현재 위치(씬 정보)
    public List<string> inventory;  // 인벤토리 아이템 목록

    public GameState(string planetName, int hp, string sceneName, List<string> inventory)
    {
        this.planetName = planetName;
        this.hp = hp;
        this.sceneName = sceneName;
        this.inventory = inventory;
    }
}