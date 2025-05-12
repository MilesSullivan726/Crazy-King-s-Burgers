using UnityEngine;

public class SpriteGroupVisibility : MonoBehaviour
{
    public void SetGroupVisible(bool visible)
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>(true);
        foreach (var sr in sprites)
        {
            sr.enabled = visible;
        }
    }
}
