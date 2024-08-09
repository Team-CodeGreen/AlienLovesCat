using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest System/Quest")]
public class Quest : ScriptableObject
{
    public string title;
    public string description;
    public bool isCompleted;

    public List<Item> requiredItems; // ����Ʈ �Ϸῡ �ʿ��� ������ ���
    private Dictionary<Item, bool> collectedItems; // ȹ���� �������� ����
    public void Initialize(string title, string description)
    {
        this.title = title;
        this.description = description;
        this.isCompleted = false; 
        
        //����Ʈ�� �ʿ��� ������
        this.requiredItems = new List<Item>(requiredItems);
        collectedItems = new Dictionary<Item, bool>();

        foreach (Item item in requiredItems)
        {
            collectedItems[item] = false; // �ʱ� ���´� ��� ��ȹ�� ����
        }
    }

    public void Complete()
    {
        isCompleted = true;
    }

    public void CollectItem(Item item)
    {
        if (collectedItems.ContainsKey(item))
        {
            collectedItems[item] = true; // �������� ȹ���� ���·� ǥ��

            // ��� �������� ȹ���ߴ��� Ȯ��
            isCompleted = CheckCompletion();
        }
    }

    private bool CheckCompletion()
    {
        foreach (bool collected in collectedItems.Values)
        {
            if (!collected)
            {
                return false;
            }
        }
        return true;
    }
}