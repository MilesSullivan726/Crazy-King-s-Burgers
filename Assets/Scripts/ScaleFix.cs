using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class ScaleFix : MonoBehaviour
{
    [Range(0.9f, 1.0f)]
    public float scaleMargin = 0.98f; // Reduce scale to prevent clipping

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Camera cam = Camera.main;

        // Screen size in world units
        float screenWorldHeight = 2f * cam.orthographicSize;
        float screenWorldWidth = screenWorldHeight * Screen.width / Screen.height;

        // Sprite size in world units
        Sprite sprite = sr.sprite;
        float spriteWidth = sprite.rect.width / sprite.pixelsPerUnit;
        float spriteHeight = sprite.rect.height / sprite.pixelsPerUnit;

        // Determine scale to fit screen
        float scaleX = screenWorldWidth / spriteWidth;
        float scaleY = screenWorldHeight / spriteHeight;
        float finalScale = Mathf.Min(scaleX, scaleY) * scaleMargin;

        // Apply scale
        transform.localScale = new Vector3(finalScale, finalScale, 1f);
    }
}

