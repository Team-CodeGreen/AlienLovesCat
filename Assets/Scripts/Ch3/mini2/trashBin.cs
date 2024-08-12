using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trashBin : MonoBehaviour
{
    public string trashType; // ������ Ÿ��
    public trashSpawner trashSpawner; // TrashSpawner ����
    public GameObject failImage; // ���� �̹����� ���� (�� ���������� Canvas ���� Image ������Ʈ)
    public GameObject goodImage; // Good �̹����� ���� (�� ���������� Canvas ���� Image ������Ʈ)

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        Trash trash = other.gameObject.GetComponent<Trash>(); // �浹�� �������� Trash ��ũ��Ʈ ��������

        if (trash != null)
        {
            if (trash.trashType == trashType)
            {
                Debug.Log("Correct bin!");
                ScoreManager.Instance.AddScore(trash.scoreValue); // �������� ���� ���� �߰�
                ShowGoodImage(); // Good �̹��� ǥ��
            }
            else
            {
                Debug.Log("Wrong bin!");
                ShowFailImage(); // ���� �̹��� ǥ��
            }

            Destroy(other.gameObject); // ���� ������ ����
            trashSpawner.SpawnTrash(); // ���� ������ ����
        }
    }

    void ShowFailImage()
    {
        if (failImage != null)
        {
            failImage.SetActive(true); // ���� �̹��� Ȱ��ȭ
            Invoke("HideFailImage", 2f); // 2�� �Ŀ� �̹����� ����
        }
    }

    void HideFailImage()
    {
        if (failImage != null)
        {
            failImage.SetActive(false); // ���� �̹��� ��Ȱ��ȭ
        }
    }

    void ShowGoodImage()
    {
        if (goodImage != null)
        {
            goodImage.SetActive(true); // Good �̹��� Ȱ��ȭ
            Invoke("HideGoodImage", 2f); // 2�� �Ŀ� �̹����� ����
        }
    }

    void HideGoodImage()
    {
        if (goodImage != null)
        {
            goodImage.SetActive(false); // Good �̹��� ��Ȱ��ȭ
        }
    }
}