using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trashBin : MonoBehaviour
{
    public string trashType; // ������ Ÿ��
    public trashSpawner trashSpawner; // TrashSpawner ����

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name); // �浹 Ȯ��

        if (other.gameObject.CompareTag(trashType))
        {
            Debug.Log("Correct bin!"); // �ùٸ� �������� Ȯ��
            ScoreManager.Instance.AddScore(10); // ���� �߰�
        }
        else
        {
            Debug.Log("Wrong bin!"); // �߸��� �������� Ȯ��
        }

        // ���� ������ ����
        Destroy(other.gameObject);
        // ���� ������ ����
        trashSpawner.SpawnTrash();
    }
}