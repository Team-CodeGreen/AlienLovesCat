using System.Collections.Generic;

[System.Serializable]
public class GameState
{
    public string planetName;  // �༺ �̸�
    public int hp;             // �÷��̾��� HP
    public string sceneName;   // ���� ��ġ(�� ����)
    public List<string> inventory;  // �κ��丮 ������ ���

    public GameState(string planetName, int hp, string sceneName, List<string> inventory)
    {
        this.planetName = planetName;
        this.hp = hp;
        this.sceneName = sceneName;
        this.inventory = inventory;
    }
}