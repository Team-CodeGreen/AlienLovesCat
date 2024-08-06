using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableImageCollider : MonoBehaviour
{
    public Image image; // Unity UI Image
    private Texture2D texture;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = image.GetComponent<RectTransform>();
        texture = image.sprite.texture;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 localCursor;
            var rect = rectTransform.rect;

            // Convert screen point to local point
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, null, out localCursor))
                return;

            // Adjust local point to texture coordinates
            localCursor.x += rect.width / 2;
            localCursor.y += rect.height / 2;

            // Calculate texture coordinate
            int x = Mathf.FloorToInt((localCursor.x / rect.width) * texture.width);
            int y = Mathf.FloorToInt((localCursor.y / rect.height) * texture.height);

            // Check if the coordinates are within the texture bounds
            if (x >= 0 && x < texture.width && y >= 0 && y < texture.height)
            {
                // Check alpha value
                if (texture.GetPixel(x, y).a > 0)
                {
                    OnImageClick();
                }
            }
        }
    }

    void OnImageClick()
    {
        Debug.Log("Image clicked on non-transparent area");
        // 클릭 이벤트 처리 코드 작성
    }
}