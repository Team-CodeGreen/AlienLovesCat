using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UFOManager : MonoBehaviour
{
    public GameObject UFOButton;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 트리거에 닿은 오브젝트가 Player인지 확인
        {
            UFOButton.SetActive(true);
        }
    }
}
