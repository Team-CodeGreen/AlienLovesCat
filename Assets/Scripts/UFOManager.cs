using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UFOManager : MonoBehaviour
{
    public GameObject UFOButton;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ʈ���ſ� ���� ������Ʈ�� Player���� Ȯ��
        {
            UFOButton.SetActive(true);
        }
    }
}
