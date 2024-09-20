using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovements : MonoBehaviour
{
    public float moveSpeed = 2f; // NPC 이동 속도
    private bool movingLeft = true; // 현재 왼쪽으로 이동 중인지 여부

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
                // 왼쪽으로 이동
                for (float t = 0; t < 3f; t += Time.deltaTime)
                {
                    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                    yield return null;
                }
            }
            else
            {
                // 오른쪽으로 이동
                for (float t = 0; t < 3f; t += Time.deltaTime)
                {
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                    yield return null;
                }
            }

            // 이동 방향 변경
            movingLeft = !movingLeft;

            // 방향에 따라 NPC의 스케일 반전 (x축만)
            Vector3 npcScale = transform.localScale;
            npcScale.x *= -1; // x 축 반전
            transform.localScale = npcScale;
        }
    }
}
