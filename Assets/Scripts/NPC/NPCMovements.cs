using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovements : MonoBehaviour
{
    public float moveSpeed = 2f; // NPC �̵� �ӵ�
    private bool movingLeft = true; // ���� �������� �̵� ������ ����

    void Start()
    {
        StartCoroutine(MoveNPC());
    }

    IEnumerator MoveNPC()
    {
        while (true)
        {
            if (movingLeft)
            {
                // �������� �̵�
                for (float t = 0; t < 3f; t += Time.deltaTime)
                {
                    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                    yield return null;
                }
            }
            else
            {
                // ���������� �̵�
                for (float t = 0; t < 3f; t += Time.deltaTime)
                {
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                    yield return null;
                }
            }

            // �̵� ���� ����
            movingLeft = !movingLeft;

            // ���⿡ ���� NPC�� ������ ���� (x�ุ)
            Vector3 npcScale = transform.localScale;
            npcScale.x *= -1; // x �� ����
            transform.localScale = npcScale;
        }
    }
}
